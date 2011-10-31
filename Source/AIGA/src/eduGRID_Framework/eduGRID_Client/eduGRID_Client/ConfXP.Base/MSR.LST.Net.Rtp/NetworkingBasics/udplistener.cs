using System;
using System.Collections;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;
using MSR.LST.Net.Sockets;
using System.Net.Sockets;
using LstSocks = MSR.LST.Net.Sockets;

namespace MSR.LST.Net
{
    /// <summary>
    /// Multicast Listener is a high level class that is used to simplify the process of listening for multicast UDP packets.
    /// It does all the work for you to join the multicast group and set the proper socket settings for correct operation.
    /// 
    /// In the future, this will become more polymorphic so that you can select from one of a a number of protocols that implement the
    /// "INetworkListener" interface, such as NetworkListenerTcp, NetworkListenerUdpUnicast, NetworkListenerPgm.
    /// </summary>
    /// <example>
    /// ...
    /// MulticastUdpListener mcListener = new MulticastUdpListener(endPoint);
    /// mcListener.Receive(packetBuffer);
    /// mcListener.Displose();
    /// mcListener = null;
    /// ...
    /// </example>
    [ComVisible(false)]
    public class UdpListener : INetworkListener
    {
        #region Asynchronous ReceiveFrom functionality
        private class asyncReceiveState
        {
            internal asyncReceiveState(MSR.LST.Net.Sockets.Socket sock, BufferChunk bufferChunk, Queue queue, ReceivedFromCallback receivedFromCallback)
            {
                this.sock = sock;
                this.bufferChunk = bufferChunk;
                this.queue = queue;
                this.receivedFromCallback = receivedFromCallback;
            }

            internal MSR.LST.Net.Sockets.Socket sock = null;
            internal BufferChunk bufferChunk = null;
            internal Queue queue = null;
            internal ReceivedFromCallback receivedFromCallback = null;
        }

        public void AsyncReceiveFrom(Queue queueOfBufferChunks, ReceivedFromCallback callback)
        {
            if (disposed) // This continues in the background, so shut down if disposed
            {
                return;
            }
            // Set up the state
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint senderEP = (EndPoint)sender;
            BufferChunk bc = (BufferChunk)queueOfBufferChunks.Dequeue();
            asyncReceiveState ars = new asyncReceiveState(this.sock, bc, queueOfBufferChunks, callback);

            // Start the ReceiveFrom
            sock.BeginReceiveFrom(bc, ref senderEP, new AsyncCallback(asyncReceiveCallback), ars);
        }

        private void asyncReceiveCallback(IAsyncResult ar)
        {
            if (disposed) // This continues in the background, so shut down if disposed
            {
                return;
            }
            // Set up the state
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint senderEP = (EndPoint)sender;
            asyncReceiveState ars = (asyncReceiveState)ar.AsyncState;

            // Receive the packet
            try
            {
                ars.bufferChunk.Length = ars.sock.EndReceiveFrom(ar, ref senderEP);

                // We get back a size of 0 when the socket read fails due to timeout
                if (ars.bufferChunk.Length > 0)
                {
                    // Send the data back to the app that called AsyncReceiveFrom
                    ars.receivedFromCallback(ars.bufferChunk, senderEP);
                }
            }
            catch (Exception e)
            {
                //Pri2: This used to throw a network timeout event into the EventQueue when it was a synchronous receive
                System.Diagnostics.Debug.WriteLine(e.ToString());
                System.Diagnostics.Debugger.Break();
            }

            // Start another pending network read
            AsyncReceiveFrom(ars.queue, ars.receivedFromCallback);
        }
        #endregion
        #region Private Properties
        /// <summary>
        /// bool to tell if the Dispose method has been called, per the IDisposable pattern
        /// </summary>
        private bool disposed = false;
        /// <summary>
        /// Socket upon which the Multicast Listener works.  Note that we use the MSR.LST version of Socket in order to get BufferChunk support.
        /// </summary>
        private MSR.LST.Net.Sockets.Socket sock = null;

        /// <summary>
        /// Hold on to the multicastInterface so we can query it at a later time for diagnostic purposes
        /// </summary>
        private IPAddress externalInterface = null;

        private Random rnd = new Random();
        
        private IPEndPoint ep = null;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor that binds this object instance to an IPEndPoint.  If you need to change IPEndPoint dynamically, Dispose and recreate a new object.
        /// </summary>
        /// <param name="endPoint">IPEndPoint where we should be listening for IP Multicast packets.</param>
        /// <param name="TimeoutMilliseconds">Milliseconds before lack of a packet == a Network Timeout</param>
        /// <example>
        /// ...
        /// MulticastUdpListener mcListener = new MulticastUdpListener(endPoint1);
        /// mcListener.Receive(packetBuffer);
        /// mcListener.Displose();
        ///
        /// MulticastUdpListener mcListener = new MulticastUdpListener(endPoint2);
        /// mcListener.Receive(packetBuffer);
        /// mcListener.Displose();
        ///
        /// mcListener = null;
        /// ...
        /// </example>
        public UdpListener(System.Net.IPEndPoint endPoint, int timeoutMilliseconds)
        {
            LstSocks.Socket.SockInterfacePair sip = LstSocks.Socket.GetSharedSocket(endPoint);
            this.sock = sip.sock;
            this.externalInterface = sip.extInterface;
            this.ep = endPoint;

            lock(sip)
            {
                if(!sip.Initialized)
                {
                    try
                    {
                        // Set the timeout on the socket
                        if( timeoutMilliseconds > 0 )
                            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, timeoutMilliseconds);

                        // Set the socket to send & receive from this endpoint
                        sock.Bind(new IPEndPoint(externalInterface,endPoint.Port));

                        // Make room for 80 packets plus some overhead
                        sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, 1500 * 80);

                        if(Utility.IsMulticast(endPoint.Address))
                        {
                            if(endPoint.AddressFamily == AddressFamily.InterNetworkV6)
                            {
                                // Join the IPv6 Multicast group
                                sock.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.AddMembership,
                                    new IPv6MulticastOption(endPoint.Address));
                            } 
                            else 
                            {
                                // Join the IPv4 Multicast group
                                sock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership,
                                    new MulticastOption(endPoint.Address));
                            }

                        }

                        sip.Initialized = true;
                    } 
                    catch
                    {
                        this.Dispose();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Dispose per the IDisposable pattern
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            
            if(!disposed) 
            {
                disposed = true;
                if (sock != null)
                {
                    LstSocks.Socket.ReleaseSharedSocket(ep, sock);
                    sock = null;
                }
            }
        }
        /// <summary>
        /// Destructor -- needed because we hold on to an expensive resource, a network socket.  Note that this just calls Dispose.
        /// </summary>
        ~UdpListener()
        {
            Dispose();
        }
        #endregion
        #region Public Methods

        /// <summary>
        /// Receive a packet into a BufferChunk.  This method is preferred over receiving into a byte[] because you can allocate a large
        /// byte[] in one BufferChunk and continously receiving into the buffer without recreating byte[]s and dealing with the memory allocation
        /// overhead that causes.
        /// 
        /// No int bytes received is returned because the bytes received is stored in BufferChunk.Length.
        /// </summary>
        /// <param name="packetBuffer">BufferChunk</param>
        /// <example>
        /// ...
        /// MulticastUdpListener mcListener = new MulticastUdpListener(endPoint);
        ///
        /// // Allocate a 2K buffer to hold the incoming packet
        /// BufferChunk packetBuffer = new BufferChunk(2000);
        ///
        /// mcListener.Receive(packetBuffer);
        ///
        /// mcListener.Displose();
        /// mcListener = null;
        /// ...
        /// </example>
        public void Receive(BufferChunk packetBuffer)
        {
            if (disposed) throw new ObjectDisposedException("MulticastUdpListener already exposed");

            sock.Receive(packetBuffer);
#if FaultInjection
            if ( dropPacketsReceivedPercent > 0 )
            {
                while (rnd.Next(0,100) < dropPacketsReceivedPercent)
                {
                    sock.Receive(packetBuffer);
                }
            }
#endif
        }
        /// <summary>
        /// Same as Receive, but you also get an EndPoint containing the sender of the packet.
        /// </summary>
        /// <param name="packetBuffer">BufferChunk</param>
        /// <param name="endPoint">EndPoint</param>
        /// <example>
        /// ...
        /// MulticastUdpListener mcListener = new MulticastUdpListener(endPoint);
        ///
        /// // Allocate a 2K buffer to hold the incoming packet
        /// BufferChunk packetBuffer = new BufferChunk(2000);
        ///
        /// // Allocate a structure to hold the incoming endPoint
        /// EndPoint endPoint;
        ///
        /// mcListener.ReceiveFrom(packetBuffer, endPoint);
        ///
        /// mcListener.Displose();
        /// mcListener = null;
        /// ...
        /// </example>
        public void ReceiveFrom(BufferChunk packetBuffer, out EndPoint endPoint)
        {
            if (disposed) throw new ObjectDisposedException("MulticastUdpListener already exposed");

            endPoint = new IPEndPoint(externalInterface,0);
            sock.ReceiveFrom(packetBuffer, ref endPoint);
#if FaultInjection
            if ( dropPacketsReceivedPercent > 0 )
            {
                while (rnd.Next(0,100) < dropPacketsReceivedPercent)
                {
                    sock.ReceiveFrom(packetBuffer, ref endPoint);
                }
            }
#endif
        }
        #endregion
        #region Public Properties
        /// <summary>
        /// Get the IP address of the Local Multicast Interface -- used for diagnostic purposes
        /// </summary>
        public IPAddress ExternalInterface
        {
            get
            {
                return externalInterface;
            }
        }
        #endregion
        #region Fault Injection
#if FaultInjection
        internal int dropPacketsReceivedPercent = 0;
        public int DropPacketsReceivedPercent
        {
            get
            {
                return dropPacketsReceivedPercent;
            }
            set
            {
                if (value > 100 || value < 0)
                    throw new ArgumentException("DropPacketsReceivedPercent must be between 0 and 100");
                dropPacketsReceivedPercent = value;
            }
        }
#endif
        #endregion
    }

}
