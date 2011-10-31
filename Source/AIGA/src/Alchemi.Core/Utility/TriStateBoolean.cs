#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  TriStateBoolean.cs
* Project       :  Alchemi.Core.Utility
* Created on    :  08 November 2005
* Copyright     :  Copyright © 2006 The University of Melbourne
*                    This technology has been developed with the support of
*                    the Australian Research Council and the University of Melbourne
*                    research grants as part of the Gridbus Project
*                    within GRIDS Laboratory at the University of Melbourne, Australia.
* Author        :  Tibor Biro (tb@tbiro.com)
* License       :  GPL
*                    This program is free software; you can redistribute it and/or
*                    modify it under the terms of the GNU General Public
*                    License as published by the Free Software Foundation;
*                    See the GNU General Public License
*                    (http://www.gnu.org/copyleft/gpl.html) for more 
details.
*
*/
#endregion

using System;

namespace Alchemi.Core.Utility
{
	/// <summary>
	/// Define a structure that holds a tri state boolean value: true, false, undefined
	/// </summary>
	public struct TriStateBoolean
	{
		private Int32 m_value;

		public static readonly TriStateBoolean True = new TriStateBoolean(1);
		public static readonly TriStateBoolean False = new TriStateBoolean(0);
		public static readonly TriStateBoolean Undefined = new TriStateBoolean(-1);
		
		private TriStateBoolean(Int32 value)
		{
			m_value = value;
		}

		#region "Miscellaneous"

		// NOTE: Equals must be overwritten for Value types because of the inefficient default implementation.

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			if (!(obj is TriStateBoolean))
			{
				return false;
			}

			return this.Equals ((TriStateBoolean) obj);
		}

		public Boolean Equals(TriStateBoolean obj)
		{
			return obj.m_value.Equals(m_value);
		}

		public override int GetHashCode()
		{
			return m_value.GetHashCode ();
		}

		public override string ToString()
		{
			return m_value.ToString();
		}

		#endregion

		#region "Operators"

		public static Boolean operator==(TriStateBoolean obj1, TriStateBoolean obj2)
		{
			return (obj1.Equals(obj2));
		}

		public static Boolean operator!=(TriStateBoolean obj1, TriStateBoolean obj2)
		{
			return !(obj1 == obj2);
		}
		#endregion

	}
}
