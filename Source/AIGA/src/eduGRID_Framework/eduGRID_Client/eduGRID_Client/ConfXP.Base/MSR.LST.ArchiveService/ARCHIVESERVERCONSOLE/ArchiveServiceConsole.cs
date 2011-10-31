using System;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Configuration;
using System.Diagnostics;


namespace MSR.LST.ConferenceXP.ArchiveService
{
    /// <summary>
    /// A console app to host the Archive Service during testing.
    /// </summary>
    class ArchiveServiceConsole
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("ConferenceXP Archive Service is starting");

            #region Hook us as a listner to Trace / Debug
            TraceListener tl = new TextWriterTraceListener(Console.Out);
            Trace.Listeners.Add( tl );
            #endregion

            BaseService arc = new BaseService();
            arc.Start();

            Console.WriteLine("ConferenceXP Archive Service has started listening on port " + Constants.TCPListeningPort);
            Console.WriteLine("Press 'Q' to quit");
            Console.WriteLine("----------------------------------------------------------------- \n");

            while ( Console.ReadLine() != "q");

            arc.Stop();
        }

    }

}
