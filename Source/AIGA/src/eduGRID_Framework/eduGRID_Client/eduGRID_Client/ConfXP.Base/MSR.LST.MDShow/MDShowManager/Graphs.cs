using System;
using System.Collections;
using System.Diagnostics;
using Microsoft.Win32;
using MSR.LST.Net.Rtp;
using MSR.LST.MDShow.Filters;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;


namespace MSR.LST.MDShow
{
    public sealed class FilterGraph
    {
        public enum State
        {
            Running,
            Stopped
        }
  

        /// <summary>
        /// This class only provides static methods and can't be inherited
        /// or instantiated
        /// </summary>
        private FilterGraph(){}


        /// <summary>
        /// Removes all filters from a graph
        /// 
        /// Important Note:
        /// If this method goes into an infinite loop, it is most likely because you are trying to
        /// remove a filter from a different thread than the one that added the filter, and your
        /// app was launched with the STAThreaded attribute on the Main method.
        /// 
        /// Either use MTAThreaded attribute, or remove filter from the same thread it was added.
        /// </summary>
        public static void RemoveAllFilters( FilgraphManagerClass fgm)
        {
            IFilterGraph iFG = (IFilterGraph)fgm;
            IEnumFilters iEnum;
            iFG.EnumFilters(out iEnum);

            uint fetched;
            IBaseFilter iBF;
            iEnum.Next(1, out iBF, out fetched);

            while(fetched == 1)
            {
                // Remove filter from graph
                iFG.RemoveFilter(iBF);

                // Because the state of the enumerator has changed (item was removed from collection)
                iEnum.Reset();
                iEnum.Next(1, out iBF, out fetched);
            }
        }

        public static ArrayList FiltersInGraph(IFilterGraph iFG)
        {
            ArrayList ret = new ArrayList();

            IEnumFilters iEnum;
            iFG.EnumFilters(out iEnum);

            uint fetched;
            IBaseFilter iBF;
            iEnum.Next(1, out iBF, out fetched);

            while(fetched == 1)
            {
                ret.Add(iBF);
                iEnum.Next(1, out iBF, out fetched);
            }

            return ret;
        }

        public static string Debug(IFilterGraph iFG)
        {
            string ret = "\r\nFilters in graph\r\n";

            foreach(IBaseFilter iBF in FiltersInGraph(iFG))
            {
                ret += string.Format("\t{0}\r\n", Filter.Name(iBF));
            }

            return ret;
        }

        
        #region ROT

        [DllImportAttribute("ole32.dll")]
        private static extern int CreateItemMoniker(
            [MarshalAs(UnmanagedType.LPWStr)] string delim, 
            [MarshalAs(UnmanagedType.LPWStr)] string name,
            out IMoniker ppmk);
        
        [DllImport("ole32.dll")]
        private static extern int GetRunningObjectTable(
            int reserved, out IRunningObjectTable ROT);

        public static UInt32 AddToRot(IGraphBuilder graph)
        {
            int hr;

            IRunningObjectTable rot;
            hr = GetRunningObjectTable(0, out rot);
            Marshal.ThrowExceptionForHR(hr);

            IMoniker moniker;
            hr = CreateItemMoniker("!", string.Format("FilterGraph {0:x8} pid {1:x8}", 
                new Random().Next(), System.Diagnostics.Process.GetCurrentProcess().Id), out moniker);
            Marshal.ThrowExceptionForHR(hr);

            UInt32 register;
            rot.Register(1, graph, moniker, out register);

            return register;
        }

        
        public static void RemoveFromRot(UInt32 register)
        {
            IRunningObjectTable rot;
            GetRunningObjectTable(0, out rot);

            rot.Revoke(register);
        }

        
        #endregion ROT
    }

    
    public abstract class CaptureGraph
    {
        #region Members

        private FilgraphManagerClass fgm;
        private IGraphBuilder iGB;
        private IFilterGraph iFG;

        private uint rotID;

        private SourceFilter source;
        private Compressor compressor;
        private Renderer renderer;

        #endregion Members

        #region Constructor, Dispose

        protected CaptureGraph(FilterInfo fiSource)
        {
            try
            {
                // Fgm initialization
                fgm = new FilgraphManagerClass();
                iFG = (IFilterGraph)fgm;
                iGB = (IGraphBuilder)fgm;
                rotID = FilterGraph.AddToRot(iGB);
        
                // Create source filter and initialize it
                source = (SourceFilter)Filter.CreateFilter(fiSource);
                iGB.AddFilter(source.BaseFilter, source.FriendlyName);
                source.AddedToGraph(fgm);
            }
            catch(Exception)
            {
                Cleanup();
                throw;
            }
        }


        public virtual void Dispose()
        {
            Cleanup();
        }


        #endregion Constructor, Dispose

        #region Public

        public FilgraphManagerClass FilgraphManager
        {
            get{return fgm;}
        }

        public IFilterGraph IFilterGraph
        {
            get { return iFG; }
        }

        public IGraphBuilder IGraphBuilder
        {
            get { return iGB; }
        }


        public virtual SourceFilter Source
        {
            get{return (SourceFilter)source;}
        }

        public virtual Compressor Compressor
        {
            get{return compressor;}
        }

        public virtual Renderer Renderer
        {
            get
            {
                return renderer;
            }
        }


        public void AddCompressor(FilterInfo fiCompressor)
        {
            RemoveCompressor();

            compressor = (Compressor)Filter.CreateFilter(fiCompressor);
            iGB.AddFilter(compressor.BaseFilter, compressor.FriendlyName);
            compressor.AddedToGraph(fgm); // Chooses input pin

            try
            {
                iGB.Connect(source.OutputPin, compressor.InputPin);
            }
            catch(COMException)
            {
                RemoveCompressor();
                throw;
            }
        }

        public void AddRenderer(FilterInfo fiRenderer)
        {
            RemoveRenderer();

            renderer = (Renderer)Filter.CreateFilter(fiRenderer);
            iGB.AddFilter(renderer.BaseFilter, renderer.FriendlyName);
            renderer.AddedToGraph(fgm); // Chooses input pin

            IPin pin = compressor == null ? source.OutputPin : compressor.OutputPin;

            try
            {
                iGB.Connect(pin, renderer.InputPin);
            }
            catch(COMException)
            {
                RemoveRenderer();
                throw;
            }
        }

        /// <summary>
        /// Removes everything downstream of the source
        /// </summary>
        public void RemoveCompressor()
        {
            RemoveFiltersDownstreamFrom(source);
        }
        
        public void RemoveRenderer()
        {
            Filter start = compressor != null ? (Filter)compressor : source;
            RemoveFiltersDownstreamFrom(start);
        }
        
        /// <summary>
        /// Removes all filters from the graph, starting at the end and working
        /// back to but not including "start"
        /// </summary>
        public void RemoveFiltersDownstreamFrom(Filter start)
        {
            if(start == null)
            {
                string msg = "Null is not a valid value for parameter 'start'";
                
                Debug.Fail(msg);
                throw new ArgumentNullException("start", msg);
            }

            if(start != source && start != compressor)
            {
                string msg = "The 'start' parameter must be either the 'source' or 'compressor' filter";

                Debug.Fail(msg);
                throw new ArgumentOutOfRangeException("start", msg);
            }


            Stop();

            foreach(IBaseFilter iBF in FilterGraph.FiltersInGraph(iFG))
            {
                if(iBF == start.BaseFilter)
                {
                    // We're done if we are back to the start filter
                    break;
                }

                iFG.RemoveFilter(iBF);
            }

            DisposeRenderer();

            if(start == source)
            {
                DisposeCompressor();
            }
        }
        

        public void RenderLocal()
        {
            if(renderer != null)
            {
                string msg = "Can't RenderLocal when graph is already rendered";
                System.Diagnostics.Debug.Fail(msg);
                throw new InvalidOperationException(msg);
            }

            IPin pin = compressor != null ? (IPin)compressor.OutputPin : source.OutputPin;
            iGB.Render(pin);
        }

        public void RenderNetwork(RtpSender rtpSender)
        {
            if(rtpSender == null)
            {
                string msg = "Null is not a valid value for parameter 'rtpSender'";
                
                Debug.Fail(msg);
                throw new ArgumentNullException("rtpSender", msg);
            }

            renderer = (Renderer)Filter.NetworkRenderer();
            ((IRtpRenderer)renderer.BaseFilter).Initialize(rtpSender);
            iGB.AddFilter(renderer.BaseFilter, renderer.FriendlyName);
            renderer.AddedToGraph(fgm);

            // Connect last pin (device or compressor) to the network renderer
            iGB.Connect(compressor != null ? compressor.OutputPin : source.OutputPin,
                renderer.InputPin);
        }
    

        /// <summary>
        /// Start sending the data stream.
        /// </summary>
        public void Run()
        {
            if (fgm != null)
            {
                fgm.Run();
            }
        }

        /// <summary>
        /// Stop sending the data stream.
        /// </summary>
        public void Stop()
        {
            if (fgm != null)
            {
                fgm.Stop();
            }
        }

    
        #endregion Public

        #region Private

        private void Cleanup()
        {
            if(fgm != null)
            {
                fgm.Stop();
                FilterGraph.RemoveAllFilters(fgm);
                FilterGraph.RemoveFromRot(rotID);
            
                iGB = null;
                iFG = null;
                fgm = null;
            }

            DisposeSource();
            DisposeCompressor();
            DisposeRenderer();
        }

        private void DisposeSource()
        {
            if(source != null)
            {
                source.Dispose();
                source = null;
            }
        }

        private void DisposeCompressor()
        {
            if(compressor != null)
            {
                compressor.Dispose();
                compressor = null;
            }
        }

        private void DisposeRenderer()
        {
            if(renderer != null)
            {
                renderer.Dispose();
                renderer = null;
            }
        }
                

        #endregion Private
    }

    public class VideoCaptureGraph : CaptureGraph
    {
        #region Constructor

        public VideoCaptureGraph(FilterInfo fiSource) : base(fiSource){}

        
        #endregion Constructor

        #region Public

        public VideoSource VideoSource
        {
            get{return (VideoSource)Source;}
        }

        public VideoCompressor VideoCompressor
        {
            get{return (VideoCompressor)Compressor;}
        }

        
        #endregion Public
    }

    public class AudioCaptureGraph : CaptureGraph
    {
        #region Constructor

        public AudioCaptureGraph(FilterInfo fiSource) : base(fiSource){}


        #endregion Constructor

        #region Public

        public AudioSource AudioSource
        {
            get{return (AudioSource)Source;}
        }

        public AudioCompressor AudioCompressor
        {
            get{return (AudioCompressor)Compressor;}
        }


        #endregion Public
    }
}
