using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Department.DAL
{
    public class SQLService
    {

		private string connectionString;
		public SQLService()
		{
			connectionString = ConfigurationManager.ConnectionStrings["IConnectionString"].ConnectionString;
		}

		public void OperationChangeInBD(string commandText, SqlParameter[] values)
		{
			SqlConnection connection = new SqlConnection(connectionString);

			connection.Open();
			SqlCommand cmd = connection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = commandText;
			cmd.Parameters.AddRange(values);
			cmd.ExecuteNonQuery();
			connection.Close();
		}


		public BindingList<T> OperationReadInBD<T>(string commandText, SqlParameter[] values, Func<SqlDataReader, T> readerEntity)
		{
			BindingList<T> entities = new BindingList<T>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = commandText;
					if (values!=null)
						command.Parameters.AddRange(values);
					connection.Open();
					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							entities.Add(readerEntity(reader));
						}
					}
					connection.Close();
				}
			}
			return entities;
		}

		public BindingList<T> OperationReadInBD<T>(string commandText, Func<SqlDataReader, T> readerEntity)
		{
			SqlParameter[] emptyParameter = new SqlParameter[0];
			return OperationReadInBD<T>(commandText, emptyParameter, readerEntity);
		}

		public int OperationReadInBD(string commandText)
		{
			int id = 0;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = commandText;
					
					connection.Open();
					using (var reader = command.ExecuteReader())
					{
						id = reader.GetInt32(0);
					}
					connection.Close();
				}
			}
			return id;
		}
	}
}
