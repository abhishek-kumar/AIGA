using System; // Used for Console and other basic definitions
using System.Net; // Used for IPEndPoint, IPAddress
using System.Net.Sockets; // Used for TcpClient, TcpListener, Socket and NetworkStream.
using System.Runtime.Serialization.Formatters.Binary; // Used for sending an object through the network stream
using ReflectorCommonLib;  // Reflector Common Library used to share the message class definition between client and server.
using System.Threading;
using MSR.LST.Net;
using System.Diagnostics;
using System.Collections;

namespace MSR.LST.ConferenceXP.ReflectorService
{
    /// <summary>
    /// Represents an unicast client entry in the clientRegTable
    /// </summary>
    public class ClientEntry
    {
        #region Members

        private IPAddress clientIP;
        private IPEndPoint groupEP;
        private DateTime joinTime;
        private int confirmNumber;
        private DateTime lastRtcp;

        #endregion Members

        #region Constructors

        internal ClientEntry(IPAddress clientIP, IPEndPoint groupEP, 
            DateTime joinTime, int confirmNumber, DateTime lastRtcp)
        {
            this.clientIP = clientIP;
            this.groupEP = groupEP;
            this.joinTime = joinTime;
            this.confirmNumber = confirmNumber;
            this.lastRtcp = lastRtcp;
        }

        
        #endregion Constructors

        #region Public 

        public IPAddress ClientIP
        {
            get
            {
                return clientIP;
            }
        }        

        public IPEndPoint GroupEP
        {
            get
            {
                return groupEP;
            }
        }

        public DateTime JoinTime
        {
            get
            {
                return joinTime;
            }
        }

        public int ConfirmNumber
        {
            get
            {
                return confirmNumber;
            }
        }

        public DateTime LastRTCP
        {
            get
            {
                return lastRtcp;
            }
            set
            {
                lastRtcp = value;
            }
        }

        public override string ToString()
        {
            string time = joinTime.ToString();

            return clientIP.ToString() + "\t    " + groupEP.ToString() + "\t    " +
                "\t        " + time;
        }

        #endregion Public

    }
    
    
    
    /// <summary>
    /// RegistrarServer will handle registering unicast enabled clients to join multicast groups.
    /// This class communicates with other classes only through clientRegTable. 
    /// </summary>
    public class RegistrarServer
    {
        #region Static 

        /// <summary>
        /// This dataTable is used to keep track of multicast disabled clients who are
        /// joining different groups. The table schema is as follows:
        ///            
        /// | Client IP | Group IP | Group Port | Join Time | Confirm. Num. |                     
        /// 
        /// </summary>
        private static Hashtable clientRegTable;

        public static Hashtable ClientRegTable
        {
            get { return clientRegTable; }
        }
        
        
        /// <summary>
        /// This method gets a group IP address and port as the input and returns a list of IP addresses 
        /// which have joined this group IP and port
        /// </summary>
        public static void MemberLookup(ArrayList members, IPAddress groupIP, int groupPort)
        {
            if (members == null || groupIP == null)
            {
                throw new NullReferenceException("The members ArrayList and " +
                    "IPAddress must be initialized before calling MemberLookup");
            }

            members.Clear();

            lock (clientRegTable.SyncRoot)
            {
                foreach (ClientEntry entry in clientRegTable.Values)
                {
                    if (groupIP.Equals(entry.GroupEP.Address) && groupPort.Equals(entry.GroupEP.Port))
                    {
                        members.Add(entry.ClientIP);
                    }
                }
            }
        }
        
        
        /// <summary>
        /// This method gets an IP address as the input and returns the group IP and port 
        /// which this client has joined before.
        /// </summary>
        public static IPEndPoint GroupLookup(IPAddress clientIP)
        {
            IPEndPoint foundGroup = null;

            lock (clientRegTable.SyncRoot)
            {
                ClientEntry entry = (ClientEntry)clientRegTable[clientIP];
                if (entry != null)
                {
                    foundGroup = entry.GroupEP;
                }
            }

            return foundGroup;
        }


        #endregion Static

        #region Members

        /// <summary>
        /// An index used to keep track of which types of threads are created. This index refers to an entry in 
        /// ThreadTypeData array. This index is also used as a lock to guarantee exclusive access to this array.
        /// That way we ensure one and only one thread is created per each entry in ThreadTypeData array.
        /// </summary>
        private int idxRSThreadTypeData;
 
        /// <summary>
        /// This arraylist will provide the data required for each thread.
        /// Thread 1: IPv4
        /// Thread 2: IPv6
        /// </summary>
        private TrafficType [] ThreadTypeData = null;

        /// <summary>
        /// The RegisrarServer's thread pointers. These references are used in the stop method
        /// </summary>      
        private Thread [] threadPTRs = null;
        
        /// <summary>
        /// A thread for checking to see if a client has timed out
        /// </summary>
        private Timer timeoutTimer = null;

        /// <summary>
        /// How many minutes before a client is considered timed out
        /// Default is 2 minutes, as RTCP data should arrive every 5 sec or so
        /// </summary>
        private TimeSpan timeoutPeriod = new TimeSpan(0, 2, 0);

        /// <summary>
        /// The tcpListener used for listening for incoming Join/Leave requests on IPv4
        /// </summary>
        private TcpListener tcpLv4;
        
        /// <summary>
        /// The tcpListener used for listening for incoming Join/Leave requests on IPv6
        /// </summary>
        private TcpListener tcpLv6;

        /// <summary>
        /// Log events
        /// </summary>
        private ReflectorEventLog eventLog = new ReflectorEventLog(ReflectorEventLog.Source.RegistrarServer);
        
        #endregion Members

        #region Constructors

        /// <summary>
        /// Initalizes ThreadTypeData to be used by different threads.
        /// </summary>
        /// <param name="IPv4Support"></param>
        /// <param name="IPv6Support"></param>
        public RegistrarServer(TrafficType traffTypes, TimeSpan timeoutPeriod)
        {
            if(timeoutPeriod != TimeSpan.Zero)
            {
                this.timeoutPeriod = timeoutPeriod;
            }

            clientRegTable = new Hashtable();
            if ( (traffTypes & TrafficType.IPv4andIPv6) == TrafficType.IPv4andIPv6)
            {
                ThreadTypeData = new TrafficType[2];
                ThreadTypeData[0] = TrafficType.IPv4;
                ThreadTypeData[1] = TrafficType.IPv6;
            }
            else if ( ((traffTypes & TrafficType.IPv4) == TrafficType.IPv4 ) || 
                ((traffTypes & TrafficType.IPv6) == TrafficType.IPv6 ) )
            {
                ThreadTypeData = new TrafficType[1];
                if ((traffTypes & TrafficType.IPv4) == TrafficType.IPv4)
                {
                    ThreadTypeData[0] = TrafficType.IPv4;
                }
                else
                {
                    ThreadTypeData[0] = TrafficType.IPv6;
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
        /// Starts the RegistrarServer in a separate thread and returns afterward.
        /// </summary>
        public void StartThreads() 
        {
            // Start the time out thread
            timeoutTimer = new Timer(new TimerCallback(TimeOut), null, timeoutPeriod, timeoutPeriod);

            idxRSThreadTypeData = 0;

            threadPTRs = new Thread[ThreadTypeData.Length];
            for (int i=0; i<ThreadTypeData.Length; i++)
            {
                threadPTRs[i] = new Thread(new ThreadStart(Start));
                threadPTRs[i].IsBackground = true;
                threadPTRs[i].Start();
            }
        }

        /// <summary>
        /// Cleans up the table closes the server TcpListener and stopes the RegistrarServer thread.
        /// </summary>
        public void StopThreads() 
        {
            try
            {
                timeoutTimer.Dispose();

                for (int i=0; i<ThreadTypeData.Length; i++)
                {
                    threadPTRs[i].Abort();
                    threadPTRs[i].Interrupt();

                    if ((ThreadTypeData[i] & TrafficType.IPv6) == TrafficType.IPv6 )
                    {
                        tcpLv6.Stop();
                    }
                    else
                    {
                        tcpLv4.Stop();
                    }

                    threadPTRs[i].Join(100);
                }
            }
            // On stopping the service, avoid the AbortException written in the event viewer
            catch(ThreadAbortException){}
            catch (Exception e)
            {
                eventLog.WriteEntry("RegistrarServer thread terminating exception - " + e.ToString(),
                    EventLogEntryType.Warning, (int)ReflectorEventLog.ID.ThreadStoppingException);
            }
        }
        #endregion Public thread methods

        #region Private methods

        private static RegisterMessage ProcessJoinRequest(RegisterMessage joinRequestMessage, IPAddress senderIP)
        {
            try 
            {
                // If the senderIP already exists, remove it by following the rule - the last one wins
                if (clientRegTable.ContainsKey(senderIP))
                {
                    lock (clientRegTable.SyncRoot)
                    {
                        clientRegTable.Remove(senderIP);
                    }
                }

                // Insert the new entry
                Random rnd = new Random();
                int confirmNumber = rnd.Next(1, Int32.MaxValue);

                lock (clientRegTable.SyncRoot)
                {
                    clientRegTable.Add(senderIP, new ClientEntry(senderIP, new IPEndPoint(joinRequestMessage.groupIP,
                        joinRequestMessage.groupPort), DateTime.Now, confirmNumber, DateTime.Now));

                    ReflectorMgr.PC[ReflectorPC.ID.TotalParticipants]++;
                    ReflectorMgr.PC[ReflectorPC.ID.CurrentParticipats] = clientRegTable.Count;
                }
                    
                joinRequestMessage.msgType = MessageType.Confirm;
                joinRequestMessage.confirmNumber = confirmNumber;
                joinRequestMessage.unicastPort = ReflectorMgr.ReflectorUnicastRTPListenPort;

                if (joinRequestMessage.groupIP.AddressFamily == AddressFamily.InterNetwork)
                {
                    MulticastOption mo = new MulticastOption(joinRequestMessage.groupIP,ReflectorMgr.MulticastInterfaceIP);
                    ReflectorMgr.Sockets.SockMCv4RTP.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, mo);
                    ReflectorMgr.Sockets.SockMCv4RTCP.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, mo);
                }
                else
                {
                    IPv6MulticastOption mo = new IPv6MulticastOption(joinRequestMessage.groupIP);
                    ReflectorMgr.Sockets.SockMCv6RTP.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.AddMembership, mo);
                    ReflectorMgr.Sockets.SockMCv6RTCP.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.AddMembership, mo);
                }
            }

            catch 
            {  
                joinRequestMessage.msgType = MessageType.UnknownError;
            }

            return joinRequestMessage;
        }

        private static RegisterMessage ProcessLeaveRequest(RegisterMessage leaveRequestMessage, IPAddress senderIP)
        {
            try
            {
                lock (clientRegTable.SyncRoot)
                {
                    if (clientRegTable.ContainsKey(senderIP))
                    {
                        bool drop = true;
                        clientRegTable.Remove(senderIP);
                        ReflectorMgr.PC[ReflectorPC.ID.CurrentParticipats] = clientRegTable.Count;

                        // Drop membership if no other member exists
                        foreach (ClientEntry entry in clientRegTable.Values)
                        {
                            if (entry.GroupEP.Address.Equals(leaveRequestMessage.groupIP))
                            {
                                drop = false;
                                break;
                            }
                        }

                        if (drop)
                        {
                            if (leaveRequestMessage.groupIP.AddressFamily == AddressFamily.InterNetwork)
                            {
                                MulticastOption mo = new MulticastOption(leaveRequestMessage.groupIP,ReflectorMgr.MulticastInterfaceIP);
                                ReflectorMgr.Sockets.SockMCv4RTP.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.DropMembership, mo);
                                ReflectorMgr.Sockets.SockMCv4RTCP.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.DropMembership, mo);
                            }
                            else
                            {
                                IPv6MulticastOption mo = new IPv6MulticastOption(leaveRequestMessage.groupIP);
                                ReflectorMgr.Sockets.SockMCv6RTP.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.DropMembership, mo);
                                ReflectorMgr.Sockets.SockMCv6RTCP.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.DropMembership, mo);
                            }
                        }

                        return new RegisterMessage(MessageType.Confirm, leaveRequestMessage.groupIP, leaveRequestMessage.groupPort, leaveRequestMessage.confirmNumber);
                    }
                    else
                    {   // No entries found for the leave request
                        return new RegisterMessage(MessageType.LeaveWithoutJoinError, IPAddress.Any);
                    }
                } 
            }

            catch 
            { 
                return new RegisterMessage(MessageType.UnknownError, IPAddress.Any);
            }
        }

        public static void ForceLeave(ClientEntry client)
        {
            RegisterMessage leaveMessage = new RegisterMessage(MessageType.Leave, 
                client.GroupEP.Address, client.GroupEP.Port, client.ConfirmNumber);

            ProcessLeaveRequest(leaveMessage, client.ClientIP);
        }

        private void TimeOut(object state)
        {
            // Iterate through all of the client entries and see if any have timed out
            lock (clientRegTable.SyncRoot)
            {
                foreach (ClientEntry client in new ArrayList(clientRegTable.Values))
                {
                    if ((DateTime.Now - client.LastRTCP) > timeoutPeriod)
                    {
                        try
                        {
                            ForceLeave(client);
                        }
                        finally
                        {
                            try
                            {
                                eventLog.WriteEntry("Unicast client time out, IP:" + 
                                    client.ClientIP.ToString(), EventLogEntryType.Warning, (int)ReflectorEventLog.ID.TimeOut);
                            }
                            catch(Exception){} // Nothing to do
                        }
                    }
                }
            }
        }


        #endregion Private methods

        #region Public methods
        /// <summary>
        /// Starts listening in an infinite loop for incomming connections from RegistrarClient. Here are the
        /// scenarios:
        ///   Client Request                    Client Status in Table        Table Action     Server Response to Client
        ///   -------------------               ----------------------        ------------     -------------------------
        /// 1 Msg(Join,GIP,GP,N)              (CIP, GIP, GP) entry NOT FOUND     Insert     Msg(Confirm,GIP,GP,RndConfirmNum)
        /// 2 Msg(Join,GIP,GP,N)               (CIP, GIP, GP) entry FOUND         None      Msg(ReConfirm,GIP,GP,FoundConfirmNum)
        /// 3 Msg(Leave,GIP,GP,ConfirmNum)      Entry Found ConirmNum match      Delete     Msg(Confirm,GIP,GP,FoundConfirmNum)
        /// 4 Msg(Leave,GIP,GP,ConfirmNum)     Entry Found ConirmNum mismatch     None      Msg(ConfirmNumMismatchError,0,0,0)
        /// 5 Msg(Leave,GIP,GP,ConfirmNum)          Entry Not Found               None      Msg(LeaveWithoutJoinError,0,0,0)  
        /// 6 Msg(Leave,GIP,GP,ConfirmNum)          Lookup Error                  None      Msg(UnknownError,0,0,0) 
        /// 
        /// </summary>
        public void Start()
        {
            TrafficType traffTypes = TrafficType.None;

            if (idxRSThreadTypeData < ThreadTypeData.Length)
            {
                lock (ThreadTypeData)
                {
                    traffTypes = ThreadTypeData[idxRSThreadTypeData];
                    System.Threading.Thread.CurrentThread.Name = "Reflector_RegistrarServer_" + traffTypes.ToString();
                    idxRSThreadTypeData++;
                }
            }
            else
            {
                throw new Exception("Number of created threads exceed the number of thread types defined.");
            }
 
            IPEndPoint localEP;

            if ((traffTypes & TrafficType.IPv6) == TrafficType.IPv6)
            {
                localEP = new IPEndPoint(IPAddress.IPv6Any,ReflectorMgr.RegistrarServerPort);
            }
            else
            {
                localEP = new IPEndPoint(IPAddress.Any,ReflectorMgr.RegistrarServerPort);
            }

            // Initializing the TCP server
            NetworkStream netStream;
            
            BinaryFormatter bf = new BinaryFormatter(); 
            Object obj;

            RegisterMessage regMsg , regMsgResponse; 
            
            // Initializing the TcpListener

            TcpListener tcpL = new TcpListener(localEP);
            if ((traffTypes & TrafficType.IPv6) == TrafficType.IPv6)
            {
                tcpLv6 = tcpL;
            }
            else
            {
                tcpLv4 = tcpL;
            }
            
            tcpL.Start();
            Socket srvS = null;

            // An inifinite loop which works as follows:
            //  1. Block until a connection arrives.
            //   2. If it is a join request
            //       Lookup (ClientIP,GroupIP,GroupPort) and send back Confirm or ReConfirm
            //   2. If it is a leave request
            //       Lookup (ClientIP,GroupIP,GroupPort) and if exist send back Confirm or ConfirmNumMismatch
            //                                               if not exist send back LeaveWithoutJoinError
            //                                               if unknown error send back UnknownError
            //   2. If neither join nor leave
            //       send back InvalidRequest 
            //  3. Close the connection.
            //
            while (true) 
            {
                try
                {
                    srvS = tcpL.AcceptSocket();  // Can't use AcceptTcpClient since the client information is protected

                    netStream = new NetworkStream(srvS, System.IO.FileAccess.ReadWrite, true);  //Getting a network stream so I can serialize the class into it.
                                        
                    // Getting the request Object from stream
                    obj = bf.Deserialize(netStream); 
                    regMsg = (RegisterMessage) obj;

                    eventLog.WriteEntry("RegistrarServer: Received Request:" + regMsg.ToString(),
                        EventLogEntryType.Information, (int)ReflectorEventLog.ID.JoinLeave);

                    switch (regMsg.msgType)
                    {
                        case MessageType.Join: 
                            // Processing Join Request
                            regMsgResponse = ProcessJoinRequest(regMsg,((IPEndPoint)srvS.RemoteEndPoint).Address);
                            break;

                        case MessageType.Leave:
                            // Processing Leave Request
                            regMsgResponse = ProcessLeaveRequest(regMsg,((IPEndPoint)srvS.RemoteEndPoint).Address);
                            break;
 
                        default: // Invalid Message Type
                            regMsgResponse = new RegisterMessage(MessageType.InvalidRequest, IPAddress.Any);
                            break;
                    }

                    bf.Serialize(netStream, regMsgResponse);

                    netStream.Close();
                    srvS.Close();
                } 
                // On stopping the service, avoid the AbortException written in the event viewer
                catch(ThreadAbortException){}
                catch (Exception e)
                {
                    eventLog.WriteEntry("RegistrarServer: Network Error while receiving/sending request message. Client: " 
                        + ((srvS!=null)?((IPEndPoint) srvS.RemoteEndPoint).ToString():"") + " " + e.ToString(),
                        EventLogEntryType.Error, (int)ReflectorEventLog.ID.Error);
                }
            } // end while
        } // end Start method
        #endregion Public methods
    }
}
