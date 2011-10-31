#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	GNode.cs
* Project		:	Alchemi Core
* Created on	:	2003
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@csse.unimelb.edu.au), Rajkumar Buyya (raj@csse.unimelb.edu.au), and Krishna Nadiminti (kna@csse.unimelb.edu.au)
* License        :  GPL
*					This program is free software; you can redistribute it and/or 
*					modify it under the terms of the GNU General Public
*					License as published by the Free Software Foundation;
*					See the GNU General Public License 
*					(http://www.gnu.org/copyleft/gpl.html) for more details.
*
*/ 
#endregion

using System;
using System.Collections;
using System.ComponentModel;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Alchemi.Core.Owner;

namespace Alchemi.Core
{
	/// <summary>
	/// Represents a grid node
	/// </summary>
    public abstract class GNode : Component
    {

		// Create a logger for use in this class
		private static readonly Logger logger = new Logger();

        //----------------------------------------------------------------------------------------------- 
        // member variables
        //----------------------------------------------------------------------------------------------- 
        
		private const string DefaultRemoteObjectPrefix = "Alchemi_Node";
		private string _RemoteObjPrefix = DefaultRemoteObjectPrefix;
		private bool _ChannelRegistered = false;
        private IManager _Manager = null;
        private RemoteEndPoint _ManagerEP = null;
        private OwnEndPoint _OwnEP = null;
        private TcpChannel _Channel = null;
        private SecurityCredentials _Credentials;
        private bool _Initted = false;
        private GConnection _Connection;

        //----------------------------------------------------------------------------------------------- 
        // properties
        //----------------------------------------------------------------------------------------------- 
    
		/// <summary>
		/// Gets the manager
		/// </summary>
        public IManager Manager
        {
            get { return _Manager; }
        }
    
		/// <summary>
		/// Gets the manager end point
		/// </summary>
        public RemoteEndPoint ManagerEP
        {
            get { return _ManagerEP; }
        }

		/// <summary>
		/// Gets the node end point
		/// </summary>
        public OwnEndPoint OwnEP
        {
            get { return _OwnEP; }
        }

		/// <summary>
		/// Gets the security credentials
		/// </summary>
        public SecurityCredentials Credentials
        {
            get { return _Credentials; }
        }

		/// <summary>
		/// Gets or sets the GConnection
		/// </summary>
        public GConnection Connection
        {
            get
            {
                return _Connection;
            }
            set
            {
                _Connection = value;
                _OwnEP = null;
                if (value != null)
                {
                    _Credentials = new SecurityCredentials(value.Username, value.Password);
                    _ManagerEP = new RemoteEndPoint(value.Host, value.Port, RemotingMechanism.TcpBinary);
                }
            }
        }

        public Alchemi.Core.Owner.GConnection GConnection
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        //----------------------------------------------------------------------------------------------- 
        // constructors
        //----------------------------------------------------------------------------------------------- 

		/// <summary>
		/// Creates a new instance of the GConnection class
		/// </summary>
        public GNode() {}
        
		/// <summary>
		/// Creates a new instance of the GConnection class
		/// </summary>
		/// <param name="managerEP">manager end point</param>
		/// <param name="ownEP">own end point</param>
		/// <param name="credentials"></param>
        public GNode(RemoteEndPoint managerEP, OwnEndPoint ownEP, SecurityCredentials credentials) : this(managerEP, ownEP, credentials, DefaultRemoteObjectPrefix)
        {
        }

		public GNode(RemoteEndPoint managerEP, OwnEndPoint ownEP, SecurityCredentials credentials, string remoteObjectPrefix)
		{
			_OwnEP = ownEP;
			_Credentials = credentials;
			_ManagerEP = managerEP;
			_RemoteObjPrefix = remoteObjectPrefix;
			Init();
		}

		/// <summary>
		/// Creates a new instance of the GConnection class
		/// </summary>
		/// <param name="connection"></param>
        public GNode(GConnection connection)
        {
            Connection = connection;
            Init();
        }
        
        //----------------------------------------------------------------------------------------------- 
        // public methods
        //----------------------------------------------------------------------------------------------- 

		/// <summary>
		/// Initialised the remoted "node"
		/// </summary>
        protected void Init()
        {
            if (_Initted)
            {
                return;
            }
            
            if (_Connection != null)
            {
                _Credentials = new SecurityCredentials(_Connection.Username, _Connection.Password);
                _ManagerEP = new RemoteEndPoint(_Connection.Host, _Connection.Port, RemotingMechanism.TcpBinary);
            }
            GetManagerRef();
            RemoteSelf();
            _Initted = true;
        }
        
        //----------------------------------------------------------------------------------------------- 
        
		/// <summary>
		/// Gets the reference to the remote node
		/// </summary>
		/// <param name="remoteEP">end point of the remote node</param>
		/// <returns>Node reference</returns>
        public static GNode GetRemoteRef(RemoteEndPoint remoteEP)
        {
			return GetRemoteRef(remoteEP, DefaultRemoteObjectPrefix);
        }

		public static GNode GetRemoteRef(RemoteEndPoint remoteEP, string remoteObjectPrefix)
		{
			switch (remoteEP.RemotingMechanism)
			{
				case RemotingMechanism.TcpBinary:
					string uri = "tcp://" + remoteEP.Host + ":" + remoteEP.Port + "/" + remoteObjectPrefix;
					return (GNode) Activator.GetObject(typeof(GNode), uri);
				default:
					return null;
			}			
		}
        
        //-----------------------------------------------------------------------------------------------          
        
		/// <summary>
		/// Gets the reference to a remote manager
		/// </summary>
		/// <param name="remoteEP">end point of the remote manager</param>
		/// <returns>Manager reference</returns>
        public static IManager GetRemoteManagerRef(RemoteEndPoint remoteEP)
        {
            IManager manager;

            try
            {
                manager = (IManager) GetRemoteRef(remoteEP);
                manager.PingManager();
            }
            catch (Exception e)
            {
                throw new RemotingException("Could not connect to Manager.", e);
            }

            return manager;
        }

        //-----------------------------------------------------------------------------------------------          
        
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public override object InitializeLifetimeService()
        {
            return null;
        }

        //----------------------------------------------------------------------------------------------- 
        // private methods
        //----------------------------------------------------------------------------------------------- 

		/*
		 * RemoteSelf:
		 * - if the own end point is valid: 
		 *	- register a new channel, if not already done.
		 *	- if successful, then marshal this GNode object over the remoting channel
		 */ 
        private void RemoteSelf()
        {
            if (_OwnEP != null)
            {
                switch (_OwnEP.RemotingMechanism)
                {
                    case (RemotingMechanism.TcpBinary):
                        if (!_ChannelRegistered)
                        {
                            try
                            {
                            	Hashtable properties = new Hashtable();

								// the name must be Empty in order to allow multiple TCP channels
								properties.Add("name", String.Empty);
								properties.Add("port", _OwnEP.Port);

                                _Channel = new TcpChannel(
									properties, 
									new BinaryClientFormatterSinkProvider(), 
									new BinaryServerFormatterSinkProvider());

								ChannelServices.RegisterChannel(_Channel);
                                _ChannelRegistered = true;
                            }
                            catch (Exception e)
                            {
                                if (
                                    object.ReferenceEquals(e.GetType(), typeof(System.Runtime.Remoting.RemotingException)) /* assuming: "The channel tcp is already registered." */
                                    |
                                    object.ReferenceEquals(e.GetType(), typeof(SocketException)) /* assuming: "Only one usage of each socket address (protocol/network address/port) is normally permitted" */
                                    )
                                {
                                    _ChannelRegistered = true;
                                }
                                else
                                {
                                    UnRemoteSelf();
                                    throw new RemotingException("Could not register channel while trying to remote self: " + e.Message, e);
                                }
                            }
                        }
            
                        if (_ChannelRegistered)
                        {
                            try
                            {
                            	RemotingServices.Marshal(this, _RemoteObjPrefix);
                            }
                            catch (Exception e)
                            {
                                UnRemoteSelf();
                                throw new RemotingException("Could not remote self.", e);
                            }
                        }
                        break;
                }
            }
        }

        //-----------------------------------------------------------------------------------------------          
    
        private void GetManagerRef()
        {
            if (_ManagerEP != null)
            {
                _Manager = GetRemoteManagerRef(_ManagerEP);
            }
        }

        //-----------------------------------------------------------------------------------------------          

		/// <summary>
		/// Unregister channel and disconnect remoting
		/// </summary>
        protected void UnRemoteSelf()
        {
            if (_OwnEP != null)
            {
                switch (_OwnEP.RemotingMechanism)
                {
                    case RemotingMechanism.TcpBinary:
                        try
                        {
                            ChannelServices.UnregisterChannel(_Channel);
                        }
                        catch {}
                        RemotingServices.Disconnect(this);
                        break;
                }
				logger.Debug("Unremoting self...done");
            }
        }
    }
}