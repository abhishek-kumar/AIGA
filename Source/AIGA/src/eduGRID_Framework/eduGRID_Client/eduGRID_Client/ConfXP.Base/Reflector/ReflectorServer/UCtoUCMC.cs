using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ReflectorCommonLib;
using MSR.LST.Net;
using System.Diagnostics;
using System.Collections;

namespace MSR.LST.ConferenceXP.ReflectorService
{
    /// <summary>
    /// This class is responsible for receiving data from Unicast side and sending it back to other Unicast
    /// clients and multicast clients.
    /// </summary>
    public class UCtoUCMC
    {

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
        private ReflectorEventLog eventLog = new ReflectorEventLog(ReflectorEventLog.Source.UCtoUCMC);

        #endregion Members

        #region Constructors
        /// <summary>
        /// Initalizes a ThreadType(s) to keep the required initalization data for threads to start
        /// </summary>
        public UCtoUCMC(TrafficType traffTypes)
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

        #endregion Constructors

        #region Public thread methods
        /// <summary>
        /// Starts an RTP and RTCP unicast to unicast/multicast forwarder threads.
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
        /// Stops the RTP and RTCP UCtoUCMC threads.
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
        /// Forwards the traffic from unicast to unicast/multicast for the given trafficType
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
                    Thread.CurrentThread.Name = "Reflector_UCtoUCMC_" + traffTypes.ToString();
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
            Socket mcRefSock = null;
            Socket ucRefSock = null;
            Socket ucSrvSock = null;
            int ucPort = 0;
            EndPoint remoteEP = null;

            switch (traffTypes)
            {
                case TrafficType.IPv4RTCP:
                    ucPort = ReflectorMgr.ReflectorUnicastRTPListenPort + 1;
                    remoteEP = new IPEndPoint(IPAddress.Any, 0);
                    mcRefSock = ReflectorMgr.Sockets.SockMCv6RTCP;
                    ucRefSock = ReflectorMgr.Sockets.SockUCv6RTCP;
                    ucSrvSock = ReflectorMgr.Sockets.SockUCv4RTCP;
                    break;
                case TrafficType.IPv6RTCP:
                    ucPort = ReflectorMgr.ReflectorUnicastRTPListenPort + 1;
                    remoteEP = new IPEndPoint(IPAddress.IPv6Any, 0);
                    mcRefSock = ReflectorMgr.Sockets.SockMCv4RTCP;
                    ucRefSock = ReflectorMgr.Sockets.SockUCv4RTCP;
                    ucSrvSock = ReflectorMgr.Sockets.SockUCv6RTCP;
                    break;
                case TrafficType.IPv4RTP:
                    ucPort = ReflectorMgr.ReflectorUnicastRTPListenPort;
                    remoteEP = new IPEndPoint(IPAddress.Any, 0);
                    mcRefSock = ReflectorMgr.Sockets.SockMCv6RTP;
                    ucRefSock = ReflectorMgr.Sockets.SockUCv6RTP;
                    ucSrvSock = ReflectorMgr.Sockets.SockUCv4RTP;
                    break;
                case TrafficType.IPv6RTP:
                    ucPort = ReflectorMgr.ReflectorUnicastRTPListenPort;
                    remoteEP = new IPEndPoint(IPAddress.IPv6Any, 0);
                    mcRefSock = ReflectorMgr.Sockets.SockMCv4RTP;
                    ucRefSock = ReflectorMgr.Sockets.SockUCv4RTP;
                    ucSrvSock = ReflectorMgr.Sockets.SockUCv6RTP;
                    break;
                default:
                    Debug.Assert(false);
                    throw new ArgumentException("Invalid traffic type combination");
            }

            #endregion

            IPAddress remoteIP = null;
            IPEndPoint groupEP = null;
            byte [] buf = new byte[1500];
            ArrayList members = new ArrayList();
            
            while (true)
            {
                try
                {
                    size = ucSrvSock.ReceiveFrom(buf, ref remoteEP);
                    
                    if ((traffTypes & TrafficType.RTP) == TrafficType.RTP)
                    {
                        ReflectorMgr.PC[ReflectorPC.ID.UnicastPacketsReceived]++;
                    }
                    else if ((traffTypes & TrafficType.RTCP) == TrafficType.RTCP)
                    {
                        // Update client's last RTCP property
                        ClientEntry entry = (ClientEntry)RegistrarServer.ClientRegTable[((IPEndPoint)remoteEP).Address];
                        entry.LastRTCP = DateTime.Now;
                    }

                    // lookup the (first) group which this client is a member of that group.
                    remoteIP = ((IPEndPoint)remoteEP).Address;
                    groupEP = RegistrarServer.GroupLookup(remoteIP);
                    if (groupEP != null) 
                    {
                        // Find the other members of the group
                        RegistrarServer.MemberLookup(members, groupEP.Address, groupEP.Port);

                        if ((traffTypes & TrafficType.RTCP) == TrafficType.RTCP)
                        {
                            groupEP = new IPEndPoint(groupEP.Address, groupEP.Port + 1);
                        }

                        // Send the data to the Multicast side
                        if (groupEP.AddressFamily == ucSrvSock.AddressFamily)
                        {
                            ucSrvSock.SendTo(buf, 0, size, SocketFlags.None, groupEP);
                        }
                        else if ((mcRefSock != null) && (groupEP.AddressFamily == ucRefSock.AddressFamily))
                        {
                            ucRefSock.SendTo(buf, 0, size, SocketFlags.None, groupEP);
                        }

                        // Send the data to all unicast client members except the sender.
                        for (int i=0; i < members.Count; i++)
                        {
                            if (!remoteIP.Equals((IPAddress)members[i])) 
                            {
                                if (((IPAddress)members[i]).AddressFamily == ucSrvSock.AddressFamily)
                                {
                                    ucSrvSock.SendTo(buf, 0, size, SocketFlags.None, new IPEndPoint((IPAddress)members[i],ucPort));
                                }
                                else if ((ucRefSock != null) && (((IPAddress)members[i]).AddressFamily == ucRefSock.AddressFamily))
                                {
                                    ucRefSock.SendTo(buf, 0, size, SocketFlags.None, new IPEndPoint((IPAddress)members[i],ucPort));
                                }
                            }
                        }

                        if ((traffTypes & TrafficType.RTP) == TrafficType.RTP)
                        {
                            ReflectorMgr.PC[ReflectorPC.ID.UCtoUCPacketsSent] += members.Count - 1;
                        }
                    }

                } 
                // On stopping the service, avoid the AbortException written in the event viewer
                catch(ThreadAbortException){}
                catch (Exception e) // Connection reset by peer! this happens occasionally when a UC client leaves.
                {
                    eventLog.WriteEntry("UCtoUCMC forwarder exception - TrafficType:" + traffTypes
                        + " Packet received from: " + remoteEP
                        + "\n" + e.ToString(), EventLogEntryType.Warning, (int)ReflectorEventLog.ID.UCtoUCMCException);
                }
            }
        }

        #endregion

    }
}