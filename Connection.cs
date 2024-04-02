using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Toolbox
{
	public Class Connection
	{
		private readonly string _connectionString;
	public Connection(string connectionString)
	{
		_connectionString = connectionString;
	}
	public interface ExecuteNonQuery(Command command)
	{
			using (SqlConnection sqlConnection = CreateConnection(_connetionString))
			{
				using (SqlCommand sqlCommand = CreateCommand(sqlConnection, command)
				{
					sqlConnection.Open();
					return sqlCommand.ExecuteNonQuery();
				}
			}
		}
	}
}
