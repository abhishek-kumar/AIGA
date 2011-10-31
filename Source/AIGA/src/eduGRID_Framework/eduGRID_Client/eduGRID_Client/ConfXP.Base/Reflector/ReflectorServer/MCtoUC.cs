using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MSR.LST.Net;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;
using ReflectorCommonLib;

namespace MSR.LST.ConferenceXP.ReflectorService
{
    /// <summary>
    /// This class is responsible for forwarding traffic from Multicast to Unicast
    /// </summary>
    public class MCtoUC
    {
        #region Constructor
        /// <summary>
        /// Creates the threadtype table based on IPv6/IPv4 support  
        /// </summary>
        public MCtoUC(TrafficType traffTypes)
        {
            if ( (traffTypes & TrafficType.IPv4andIPv6) == TrafficType.IPv4andIPv6)
            {
                ThreadTypeData = new TrafficType[4];
                ThreadTypeData[0] = TrafficType.IPv4RTP;
                ThreadTypeData[1] = TrafficType.IPv6RTP;
                ThreadTypeData[2] = TrafficType.IPv4RTCP;
                ThreadTypeData[3] = TrafficType.IPv6RTCP;
            } 
            else if ( ((traffTypes & TrafficType.IPv4) == TrafficType.IPv4 ) || 
                ((traffTypes & TrafficType.IPv6) == TrafficType.IPv6 ) )
            {
                ThreadTypeData = new TrafficType[2];
                if ((traffTypes & TrafficType.IPv4) == TrafficType.IPv4)
                {
                    ThreadTypeData[0] = TrafficType.IPv4RTP;
                    ThreadTypeData[1] = TrafficType.IPv4RTCP;
                }
                else
                {
                    ThreadTypeData[0] = TrafficType.IPv6RTP;
                    ThreadTypeData[1] = TrafficType.IPv6RTCP;
                }
            } 
            else 
            {
                Debug.Assert(false);
                throw new Exception("Either IPv6 or IPv4 should be enabled");
            }
        }

        #endregion

        #region Private Members

        /// <summary>
        /// This arraylist will provide the data required for each thread.
        /// Thread 1: RTP IPv4
        /// Thread 2: RTP IPv6
        /// Thread 3: RTCP IPv4
        /// Thread 4: RTCP IPv6
        /// </summary>
        private TrafficType [] ThreadTypeData=null;

        /// <summary>
        /// An index used to keep track of which types of threads are created. This index refers to an entry in 
        /// ThreadTypeData array. This index is also used as a lock to guarantee exclusive access to this array.
        /// That way we ensure one and only one thread is created per each entry in ThreadTypeData array.
        /// </summary>
        private int idxThreadTypeData=0;

        /// <summary>
        /// The thread variable for the multicast to unicast RTP/RTCP IPv4/IPv6 data forwarder. This variable is a member 
        /// so although the thread is created in the StartThread method, the stop routine could Interrupt 
        /// and Abort them.
        /// </summary>
        private Thread [] threadPTRs=null;
    
        /// <summary>
        /// Log events
        /// </summary>
        private ReflectorEventLog eventLog = new ReflectorEventLog(ReflectorEventLog.Source.MCtoUC);

        #endregion Private Members
        
        #region Public thread methods
        /// <summary>
        /// Starts the two threads, one for RTP forwarding and the other for RTCP forwarding
        /// </summary>
        public void StartThreads()
        {
            idxThreadTypeData = 0;

            threadPTRs = new Thread[ThreadTypeData.Length];
            for (int i=0; i<ThreadTypeData.Length; i++)
            {
                threadPTRs[i] = new Thread(new ThreadStart(Start));
                threadPTRs[i].IsBackground = true;
                threadPTRs[i].Start();
            }
        }


        /// <summary>
        /// Stops two threads, one for RTP forwarding and the other for RTCP forwarding
        /// </summary>
        public void StopThreads()
        {
            try
            {
                for (int i=0; i< threadPTRs.Length; i++)
                {
                    threadPTRs[i].Abort();
                    threadPTRs[i].Interrupt();
                    threadPTRs[i].Join(100);
                }
            }
            // On stopping the service, avoid the AbortException written in the event viewer
            catch(ThreadAbortException){}
            catch (Exception e)
            {
                eventLog.WriteEntry("MCtoUC thread terminating exception - " + e.ToString(),
                    EventLogEntryType.Warning, (int)ReflectorEventLog.ID.ThreadStoppingException);
            }
        }


        #endregion
        
        #region Public methods
        /// <summary>
        /// This method start the .
        /// </summary>
        public void Start()
        {
            int size = 0;
            TrafficType traffTypes;

            lock (ThreadTypeData)
            {
                if (idxThreadTypeData < ThreadTypeData.Length)
                {
                    traffTypes = ThreadTypeData[idxThreadTypeData];
                    Thread.CurrentThread.Name = "Reflector_MCtoUC_" + traffTypes.ToString();
                    idxThreadTypeData++;
                }
                else
                {
                    throw new Exception("Number of created threads exceed the number of thread types defined.");
                }
            }

            #region Assigning appropriate sockets to "(mc/uc)(Ref/Srv)Sock"
            // The Ref(erence) socket variables are assigned to the socket protocol that this thread is not listening on 
            // but may use for inter-protocol communication. For example if mcSrvSock is an IPv4 socket, mcRefSock would be
            // an IPv6 socket and vice versa.
            IPEndPoint ipepTmpRef = null;
            IPEndPoint ipepTmpSrv = null;
            Socket ucRefSock = null;
            Socket mcSrvSock = null;
            Socket ucSrvSock = null;
            int ucPort = 0;


            switch (traffTypes)
            {
                case TrafficType.IPv4RTCP:
                    ucPort = ReflectorMgr.ReflectorUnicastRTPListenPort + 1;
                    ipepTmpRef = new IPEndPoint(IPAddress.IPv6Any, 0);
                    ipepTmpSrv = new IPEndPoint(IPAddress.Any, 0);
                    ucRefSock = ReflectorMgr.Sockets.SockUCv6RTCP;
                    mcSrvSock = ReflectorMgr.Sockets.SockMCv4RTCP;
                    ucSrvSock = ReflectorMgr.Sockets.SockUCv4RTCP;
                    break;
                case TrafficType.IPv6RTCP:
                    ucPort = ReflectorMgr.ReflectorUnicastRTPListenPort + 1;
                    ipepTmpSrv = new IPEndPoint(IPAddress.IPv6Any, 0);
                    ipepTmpRef = new IPEndPoint(IPAddress.Any, 0);
                    ucRefSock = ReflectorMgr.Sockets.SockUCv4RTCP;
                    mcSrvSock = ReflectorMgr.Sockets.SockMCv6RTCP;
                    ucSrvSock = ReflectorMgr.Sockets.SockUCv6RTCP;
                    break;
                case TrafficType.IPv4RTP:
                    ucPort = ReflectorMgr.ReflectorUnicastRTPListenPort;
                    ipepTmpRef = new IPEndPoint(IPAddress.IPv6Any, 0);
                    ipepTmpSrv = new IPEndPoint(IPAddress.Any, 0);
                    ucRefSock = ReflectorMgr.Sockets.SockUCv6RTP;
                    mcSrvSock = ReflectorMgr.Sockets.SockMCv4RTP;
                    ucSrvSock = ReflectorMgr.Sockets.SockUCv4RTP;
                    break;
                case TrafficType.IPv6RTP:
                    ucPort = ReflectorMgr.ReflectorUnicastRTPListenPort;
                    ipepTmpSrv = new IPEndPoint(IPAddress.IPv6Any, 0);
                    ipepTmpRef = new IPEndPoint(IPAddress.Any, 0);
                    ucRefSock = ReflectorMgr.Sockets.SockUCv4RTP;
                    mcSrvSock = ReflectorMgr.Sockets.SockMCv6RTP;
                    ucSrvSock = ReflectorMgr.Sockets.SockUCv6RTP;
                    break;
                default:
                    Debug.Assert(false);
                    throw new ArgumentException("Invalid traffic type combination");
            }
            #endregion

            ArrayList members = new ArrayList();

            byte[] buf = new byte[1500];

            while (true)
            {
                try
                {
                    EndPoint sourceEP = new IPEndPoint(IPAddress.Any, 0);
                    IPPacketInformation ipPackInfo;
                    SocketFlags flags = SocketFlags.None;

                    size = mcSrvSock.ReceiveMessageFrom(buf, 0, buf.Length, ref flags, ref sourceEP,
                        out ipPackInfo);

                    IPEndPoint sourceIpe = (IPEndPoint)sourceEP;

                    // If the packet's source address is the reflector's IP address then this packet
                    // was forwarded from Unicast to Multicast by the reflector. So, we shouldn't 
                    // forward it to UC again. Also, "AND" this condition with source port 
                    // equal to 7004/7005 to have the support running the reflector and CXPClient on the
                    // same machine.
                    if ((sourceIpe.Port != ucPort) || (!sourceIpe.Address.Equals(ReflectorMgr.MulticastInterfaceIP)
                        && !sourceIpe.Address.Equals(ReflectorMgr.IPv6MulticastInterfaceIP)))
                    {
                        if ((traffTypes & TrafficType.RTP) == TrafficType.RTP)
                        {
                            ReflectorMgr.PC[ReflectorPC.ID.MulticastPacketsReceivedOther]++;
                        }

                        // Lookup the members of this multicast group.
                        RegistrarServer.MemberLookup(members, ipPackInfo.Address, 5004);
                        if (members.Count != 0)
                        {
                            // Send the data to each individual.
                            for (int j = 0; j < members.Count; j++)
                            {
                                if (((IPAddress)members[j]).AddressFamily == ucSrvSock.AddressFamily)
                                {
                                    ipepTmpSrv.Address = (IPAddress)members[j];
                                    ipepTmpSrv.Port = ucPort;
                                    ucSrvSock.SendTo(buf, 0, size, SocketFlags.None, ipepTmpSrv);
                                }
                                else if ((ucRefSock != null) && (((IPAddress)members[j]).AddressFamily == ucRefSock.AddressFamily))
                                {
                                    ipepTmpRef.Address = (IPAddress)members[j];
                                    ipepTmpRef.Port = ucPort;
                                    ucRefSock.SendTo(buf, 0, size, SocketFlags.None, ipepTmpRef);
                                }
                            }

                            if ((traffTypes & TrafficType.RTP) == TrafficType.RTP)
                            {
                                ReflectorMgr.PC[ReflectorPC.ID.MCtoUCPacketsSent] += members.Count;
                            }
                        }
                    }
                    else if ((traffTypes & TrafficType.RTP) == TrafficType.RTP)
                    {
                        ReflectorMgr.PC[ReflectorPC.ID.MulticastPacketsReceivedSelf]++;
                    }
                }
                // On stopping the service, avoid the AbortException written in the event viewer
                catch (ThreadAbortException){}
                catch (Exception e) // Connection reset by peer! this happens occasionally when a UC client leaves.
                {
                    eventLog.WriteEntry("MCtoUC " + traffTypes + " Listener Exception - " + e.ToString(),
                        EventLogEntryType.Warning, (int)ReflectorEventLog.ID.MCtoUCException);
                }
            }
        }

        #endregion
    }
}