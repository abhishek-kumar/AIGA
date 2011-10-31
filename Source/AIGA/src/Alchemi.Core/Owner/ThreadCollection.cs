#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	ThreadCollection.cs
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
using Alchemi.Core.Owner;

namespace Alchemi.Core.Owner
{
	/// <summary>
	/// Represents a collection of GThreads.
	/// </summary>
    [Serializable]
    public class ThreadCollection : System.Collections.CollectionBase
    {
		/// <summary>
		/// Gets or sets the GThread at the given index
		/// </summary>
        public GThread this[int index]
        {
            get 
            { 
                return (GThread) InnerList[index]; 
            }

            set 
            {
                InnerList[index] = value;
            }
        }

        //-----------------------------------------------------------------------------------------------    

		/// <summary>
		/// Adds a GThread object to this collection
		/// </summary>
		/// <param name="thread">the grid thread to add</param>
        public void Add(GThread thread)
        {
            InnerList.Add(thread);
        }

		//krishna added - 23May05
		//this gives more freedom to the app developer to remove the threads no longer wanted, for whatever reason
		/// <summary>
		/// Removes a GThread object from this collection IF it is in a dead / finished state.
		/// </summary>
		/// <param name="thread"></param>
		public void Remove(GThread thread)
		{
            if (thread == null)
            {
                return;
            }

			lock (InnerList)
			{
				if (thread.State == ThreadState.Dead || thread.State == ThreadState.Finished)
					InnerList.Remove(thread);
			}
		}
    }
}
