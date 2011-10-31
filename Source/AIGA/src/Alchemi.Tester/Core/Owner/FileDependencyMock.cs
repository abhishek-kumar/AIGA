#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  FileDependencyMock.cs
* Project       :  Alchemi.Tester.Core.Owner
* Created on    :  08 February 2006
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

using Alchemi.Core.Owner;

namespace Alchemi.Tester.Core.Owner
{
	/// <summary>
	/// Used to simulate a dumb FileDependency object
	/// </summary>
	public class FileDependencyMock : FileDependency
	{
		public FileDependencyMock(string fileName) : base(fileName)
		{
		}

		public override void UnPack(string fileLocation)
		{
			return;
		}
	}
}
