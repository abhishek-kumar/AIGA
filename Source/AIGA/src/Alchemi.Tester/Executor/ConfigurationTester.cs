#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  ConfigurationTester.cs
* Project       :  Alchemi.Tester.Executor
* Created on    :  13 February 2006
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

using Alchemi.Executor;

using NUnit.Framework;

namespace Alchemi.Tester.Executor
{
	/// <summary>
	/// Summary description for ConfigurationTester.
	/// </summary>
	[TestFixture]
	public class ConfigurationTester
	{
		public ConfigurationTester()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[Test]
		public void GetIdAtLocationTestSimpleScenario()
		{
			Configuration config = new Configuration();

			config.Id = new string[2];
			config.Id[0] = "zero";
			config.Id[1] = "one";

			string result = config.GetIdAtLocation(1);

			Assert.AreEqual("one", result);
		}

		[Test]
		public void GetIdAtLocationTestConfigNotInitialized()
		{
			Configuration config = new Configuration();

			string result = config.GetIdAtLocation(1);

			Assert.AreEqual(String.Empty, result);
		}

		[Test]
		public void SetIdAtLocationTestSimpleScenario()
		{
			Configuration config = new Configuration();

			config.Id = new string[2];
			config.Id[0] = "zero";
			config.Id[1] = "one";

			config.SetIdAtLocation(1, "test");

			Assert.AreEqual("test", config.Id[1]);
		}

		[Test]
		public void SetIdAtLocationTestIncreasingTheArray()
		{
			Configuration config = new Configuration();

			config.Id = new string[2];
			config.Id[0] = "zero";
			config.Id[1] = "one";

			config.SetIdAtLocation(2, "test");

			Assert.AreEqual("test", config.Id[2]);
		}

		[Test]
		public void SetIdAtLocationTestInitializingTheIdArray()
		{
			Configuration config = new Configuration();

			config.SetIdAtLocation(2, "test");

			Assert.AreEqual("test", config.Id[2]);
		}

		[Test]
		public void GetIdCountTestNoIds()
		{
			Configuration config = new Configuration();

			Assert.AreEqual(0, config.GetIdCount());
		}

		[Test]
		public void GetIdCountTestNoSeveralIds()
		{
			Configuration config = new Configuration();

			config.Id = new string[2];
			config.Id[0] = "zero";
			config.Id[1] = "one";

			Assert.AreEqual(2, config.GetIdCount());
		}

	}
}
