#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	RemoteEndPoint.cs
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

namespace Alchemi.Core
{
	/// <summary>
	/// Represents a remote end point.
	/// </summary>
    [Serializable]
    public class RemoteEndPoint : OwnEndPoint
    {
        private string _Host;
        //private int _Port;
        //private RemotingMechanism _RemotingMechanism;
    
        //-----------------------------------------------------------------------------------------------    
    
		/// <summary>
		/// Gets or sets the hostname of the remote end point
		/// </summary>
        public new string Host
        {
            get { return _Host; } 
            set { _Host = value; }
        }

//        public int Port
//        {
//            get { return _Port; }
//            set { _Port = value; }
//        }
//
//        public RemotingMechanism RemotingMechanism
//        {
//            get { return _RemotingMechanism; }
//            set { _RemotingMechanism = value; }
//        }

        //-----------------------------------------------------------------------------------------------    
		
		/// <summary>
		/// Creates an instance of the RemoteEndPoint class
		/// </summary>
		/// <param name="host"></param>
		/// <param name="port"></param>
		/// <param name="remotingMechanism"></param>
        public RemoteEndPoint(string host, int port, RemotingMechanism remotingMechanism) : base(port,remotingMechanism)
        {
            _Host = host;
            //_Port = port;
            //_RemotingMechanism = remotingMechanism;
        }
    }
}
