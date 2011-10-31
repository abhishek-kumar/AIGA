#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	GApplicationBuffered.cs
* Project		:	Alchemi Core
* Created on	:	2003
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Michael Meadows (michael@meadows.force9.co.uk)
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

namespace Alchemi.Core.Owner
{
    /// <summary>
    /// GApplicationBuffered class represents a buffered multi-use application. StartThread method has been overridden such that the thread is not immediately started rather it is placed in a thread buffer. When the thread buffer count reaches the thread buffer capacity then that thread buffer is sent to the manager as one thread. The GApplicationBuffered class should be used when there are many threads with short execution times. Under these conditions, using GApplicationBuffered class can significantly improve performance compared to using GApplication class.
    /// </summary>
    public class GApplicationBuffered : GApplication
    {
        private const int DefaultThreadBufferCapacity = 8;

        private int m_nThreadBufferCapacity;
        private GThreadBuffer m_oThreadBuffer;

        private int m_nInternalThreadId;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GApplicationBuffered() : this(DefaultThreadBufferCapacity)
        {
        }

        /// <summary>
        /// Constructor that takes the given connection.
        /// </summary>
        /// <param name="connection">connection to alchemi manager</param>
        public GApplicationBuffered(GConnection oConnection) : this(DefaultThreadBufferCapacity)
        {
            if (oConnection == null)
            {
                throw new ArgumentNullException("oConnection");
            }

            Connection = oConnection;
        }

        /// <summary>
        /// Constructor that takes the given connection and the thread buffer capacity.
        /// </summary>
        /// <param name="oConnection"></param>
        /// <param name="nThreadBufferCapacity"></param>
        public GApplicationBuffered(GConnection oConnection, int nThreadBufferCapacity) : this(nThreadBufferCapacity)
        {
            if (oConnection == null)
            {
                throw new ArgumentNullException("oConnection");
            }

            Connection = oConnection;
        }

        /// <summary>
        /// Constructor that takes the thread buffer capacity.
        /// </summary>
        /// <param name="nThreadBufferCapacity">thread buffer capacity</param>
        public GApplicationBuffered(int nThreadBufferCapacity) : base(true)
        {
            if (nThreadBufferCapacity < 1)
            {
                throw new ArgumentOutOfRangeException("nThreadBufferCapacity", nThreadBufferCapacity, "0 < nThreadBufferCapacity <= Int32.MaxValue");
            }

            m_nThreadBufferCapacity = nThreadBufferCapacity;
            m_oThreadBuffer = CreateThreadBuffer();
        }

        /// <summary>
        /// ThreadBufferCapacity property represents the thread buffer capacity. 
        /// </summary>
        public int ThreadBufferCapacity
        {
            get
            {
                return m_nThreadBufferCapacity;
            }
        }

        /// <summary>
        /// Starts the given thread indirectly by adding it to the thread buffer. When the thread buffer count reaches the thread buffer capacity then that thread buffer is sent to the manager as one thread.
        /// </summary>
        /// <param name="oThread">thread</param>
        public override void StartThread(GThread oThread)
        {
            lock (this)
            {
                // assign an internal thread id...
                oThread.SetId(m_nInternalThreadId++);

                // add thread to thread buffer...
                m_oThreadBuffer.Add(oThread);
            }
        }

        /// <summary>
        /// Handles the thread buffer full event. It flushes the thread buffer.
        /// </summary>
        /// <param name="oSender">sender</param>
        /// <param name="oEventArgs">event args</param>
        private void oThreadBuffer_Full(object oSender, EventArgs oEventArgs)
        {
            FlushThreads();
        }

        /// <summary>
        /// Flushes the thread buffer by sending the thread buffer to the manager as one thread.
        /// </summary>
        public void FlushThreads()
        {
            lock (this)
            {
                // check whether any threads to flush...
                if (m_oThreadBuffer.Count > 0)
                {
                    // remove full event handler from thread buffer...
                    m_oThreadBuffer.Full -= new FullEventHandler(oThreadBuffer_Full);

                    // start thread buffer thread...
                    base.StartThread(m_oThreadBuffer);

                    // create new thread buffer...
                    m_oThreadBuffer = CreateThreadBuffer();
                }
            }
        }

        /// <summary>
        /// Creates a thread buffer.
        /// </summary>
        private GThreadBuffer CreateThreadBuffer()
        {
            GThreadBuffer oThreadBuffer = new GThreadBuffer(m_nThreadBufferCapacity);
            oThreadBuffer.Full += new FullEventHandler(oThreadBuffer_Full);
            return oThreadBuffer;
        }

        /// <summary>
        /// Fires the thread finish event.
        /// </summary>
        /// <param name="oThread0">thread</param>
        protected override void OnThreadFinish(GThread oThread0)
        {
            GThreadBuffer oThreadBuffer = oThread0 as GThreadBuffer;
            if (oThreadBuffer != null)
            {
                foreach (GThread oThread1 in oThreadBuffer)
                {
                    Exception oException = oThreadBuffer.GetException(oThread1.Id);
                    if (oException == null)
                    {
                        base.OnThreadFinish(oThread1);
                    }
                    else
                    {
                        base.OnThreadFailed(oThread1, oException);
                    }
                }
            }
        }

        /// <summary>
        /// Fires the thread failed event.
        /// </summary>
        /// <param name="oThread0">thread</param>
        /// <param name="oException">exception</param>
        protected override void OnThreadFailed(GThread oThread0, Exception oException)
        {
            GThreadBuffer oThreadBuffer = oThread0 as GThreadBuffer;
            if (oThreadBuffer != null)
            {
                foreach (GThread oThread1 in oThreadBuffer)
                {
                    base.OnThreadFailed(oThread1, oException);
                }
            }
        }
    }
}