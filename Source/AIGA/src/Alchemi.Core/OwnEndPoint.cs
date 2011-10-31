#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	OwnEndPoint.cs
* Project		:	Alchemi Core
* Created on	:	2003
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@csse.unimelb.edu.au) and Rajkumar Buyya (raj@csse.unimelb.edu.au)
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
using System.Net;

namespace Alchemi.Core
{
	/// <summary>
	/// Represents the end point of the local node
	/// </summary>
	[Serializable]
    public class OwnEndPoint
    {
        private int _Port;
        private RemotingMechanism _RemotingMechanism;

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Gets or sets the port number of the connection to this node
		/// </summary>
        public int Port
        {
            get { return _Port; }
            set { _Port = value; }
        }
    
		/// <summary>
		/// Gets or sets the remoting mechanism used to connect to this node
		/// </summary>
        public RemotingMechanism RemotingMechanism
        {
            get { return _RemotingMechanism; }
            set { _RemotingMechanism = value; }
        }
    
        //-----------------------------------------------------------------------------------------------    
    
		/// <summary>
		/// Creates an instance of the OwnEndPoint
		/// </summary>
		/// <param name="port"></param>
		/// <param name="remotingMechanism"></param>
        public OwnEndPoint(int port, RemotingMechanism remotingMechanism)
        {
            _Port = port;
            _RemotingMechanism = remotingMechanism;
        }

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Creates an instance of the OwnEndPoint
		/// </summary>
        public RemoteEndPoint ToRemoteEndPoint()
        {
            return new RemoteEndPoint(Dns.GetHostName(), this._Port, this._RemotingMechanism);
        }

		/// <summary>
		/// Returns  the host name of this end point.
		/// </summary>
		public string Host
		{
			get
			{
				return Dns.GetHostName();
			}
		}

    }
}
