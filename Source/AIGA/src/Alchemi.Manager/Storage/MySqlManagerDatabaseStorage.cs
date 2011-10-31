#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  MySqlManagerDatabaseStorage.cs
* Project       :  Alchemi.Core.Manager.Storage
* Created on    :  30 August 2005
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
using System.Data;

using MySql.Data.MySqlClient;

namespace Alchemi.Manager.Storage
{
	/// <summary>
	/// Override some generic database calls with mySQL specific calls.
	/// This is usually done for performance reasons.
	/// </summary>
	public class MySqlManagerDatabaseStorage : GenericManagerDatabaseStorage
	{
		public MySqlManagerDatabaseStorage(String connectionString): base (connectionString)
		{
		}

		#region Database objects (SQL server specific version)

		protected override IDbConnection GetConnection (string connectionString)
		{
			return new MySqlConnection(connectionString);
		}

		protected override IDbCommand GetCommand()
		{
			return new MySqlCommand();
		}

		protected override IDataParameter GetParameter(string name, object paramValue, DbType datatype)
		{
			object value = paramValue;
			if (datatype == DbType.Guid && value!=DBNull.Value)
			{
				//logger.Debug("GUID GIVEN = "+value.ToString());
				value = new Guid(paramValue.ToString());
			}
			MySqlParameter param  = new MySqlParameter(name, value);
			param.DbType = datatype;
			return param;
		}

		protected override IDataAdapter GetDataAdapter(IDbCommand command)
		{
			return new MySqlDataAdapter(command as MySqlCommand);
		}

		#endregion

		protected override String GetSetupFileLocation()
		{
			return "MySQL";
		}

		protected override String DatabaseParameterDecoration()
		{
			return "?";
		}

		protected override String IsNullOperator
		{
			get
			{
				return "IfNull";
			}
		}


	}
}
