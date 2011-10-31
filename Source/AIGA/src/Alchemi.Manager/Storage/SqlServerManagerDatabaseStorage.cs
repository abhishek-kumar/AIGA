#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  SqlServerManagerDatabaseStorage.cs
* Project       :  Alchemi.Core.Manager.Storage
* Created on    :  30 August 2005
* Copyright     :  Copyright © 2006 The University of Melbourne
*                    This technology has been developed with the support of
*                    the Australian Research Council and the University of Melbourne
*                    research grants as part of the Gridbus Project
*                    within GRIDS Laboratory at the University of Melbourne, Australia.
* Author        :  Tibor Biro (tb@tbiro.com), Krishna Nadiminti (kna@csse.unimelb.edu.au)
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
using System.Data;
using System.Data.SqlClient;

namespace Alchemi.Manager.Storage
{
	/// <summary>
	/// Override database calls with SQL Server specific calls.
	/// This is done for performance reasons.
	/// </summary>
	public class SqlServerManagerDatabaseStorage : GenericManagerDatabaseStorage
	{

		public SqlServerManagerDatabaseStorage(String connectionString): base (connectionString)
		{
		}

		#region Database objects (SQL server specific version)

		protected override IDbConnection GetConnection (string connectionString)
		{
			return new SqlConnection(connectionString);
		}

		protected override IDbCommand GetCommand()
		{
			return new SqlCommand();
		}

		protected override IDataParameter GetParameter(string name, object paramValue, DbType datatype)
		{
			object value = paramValue;
			if (datatype == DbType.Guid && value!=DBNull.Value)
			{
				//logger.Debug("GUID GIVEN = "+value.ToString());
				value = new Guid(paramValue.ToString());
			}
			SqlParameter param  = new SqlParameter(name, value);
			param.DbType = datatype;
			return param;
		}

		protected override IDataAdapter GetDataAdapter(IDbCommand command)
		{
			return new SqlDataAdapter(command as SqlCommand);
		}

		#endregion

		protected override String GetSetupFileLocation()
		{
			return "SqlServer";
		}

	}
}
