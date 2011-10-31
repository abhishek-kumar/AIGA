#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	FileDependencyCollection.cs
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
using System.Collections;

using Alchemi.Core.Owner;

namespace Alchemi.Core.Owner
{
	/// <summary>
	/// Represents a collection of FileDependencies
	/// </summary>
    [Serializable]
    public class FileDependencyCollection : ReadOnlyCollectionBase
    {
		/// <summary>
		/// Gets the FileDependency with the given index
		/// </summary>
        public FileDependency this[int index]
        {
            get 
            { 
                return (FileDependency) InnerList[index]; 
            }
        }
    
        //-----------------------------------------------------------------------------------------------    
    
		/// <summary>
		/// Adds the given FileDependency object to this collection
		/// </summary>
		/// <param name="dependency">file dependency to add</param>
        public void Add(FileDependency dependency)
        {
			if (dependency == null)
			{
				throw new InvalidOperationException("The FileDependency Collection does not accept null values.", null);
			}
			if (Contains(dependency))
			{
				throw new InvalidOperationException("A file dependency with the same name already exists.", null);
			}

            InnerList.Add(dependency);
        }

        /// <summary>
        /// Adds the given FileDependency list to this collection
        /// </summary>
        /// <param name="dependencyList">file dependencies to add</param>
        public void Add(FileDependency[] dependencyList)
        {
            if (dependencyList == null)
            {
                throw new InvalidOperationException("The FileDependency Collection does not accept null values.", null);
            }

            foreach (FileDependency fileDep in dependencyList)
            {
                if (fileDep == null)
                {
                    throw new InvalidOperationException("The FileDependency Collection does not accept null values.", null);
                }

                if (Contains(fileDep))
                {
                    throw new InvalidOperationException("A file dependency with the same name already exists.", null);
                }

                InnerList.Add(fileDep);
            }
        }

		/// <summary>
		/// Checks if the collection already contains the given dependency.
		/// </summary>
		/// <param name="dependency">Dependency to check.</param>
		/// <returns></returns>
		public bool Contains(FileDependency dependency)
		{
			foreach (FileDependency fd in InnerList)
			{
				if (String.Compare(fd.FileName, dependency.FileName, true) == 0)
				{
					return true;
				}
			}

			return false;
		}
    }
}