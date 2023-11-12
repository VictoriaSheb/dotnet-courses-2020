using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Department.DAL.Interfaces;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department.DAL.SQL
{
    class RewardSqlDAO : IEntityDAO<Reward, RewardShort>
	{
		private SQLService serviceSQL { get; }

		public RewardSqlDAO()
		{
			serviceSQL = new SQLService();
		}

		public void Add(RewardShort reward)
		{
			SqlParameter[] values = new SqlParameter[2];
			(values[0] = new SqlParameter("@Title", SqlDbType.NVarChar)).Value = reward.Title;
			(values[1] = new SqlParameter("@Description", SqlDbType.Text)).Value = reward.Description;
			serviceSQL.OperationChangeInBD("AddReward", values);
		}

		public void Remove(Reward reward)
		{
			SqlParameter[] values = new SqlParameter[1];
			(values[0] = new SqlParameter("@Id", SqlDbType.Int)).Value = reward.Id;
			serviceSQL.OperationChangeInBD("RemoveRewardById", values);
		}

		public void Edit(Reward reward)
		{
			SqlParameter[] values = new SqlParameter[3];
			(values[0] = new SqlParameter("@Id", SqlDbType.Int)).Value = reward.Id;
			(values[1] = new SqlParameter("@Title", SqlDbType.NVarChar)).Value = reward.Title;
			(values[2] = new SqlParameter("@Description", SqlDbType.Text)).Value = reward.Description;
			serviceSQL.OperationChangeInBD("UpdateReward", values);
		}


		public IEnumerable<Reward> GetList()
		{
			string commandText = "SELECT Id, Title, Description  FROM Rewards";
			return serviceSQL.OperationReadInBD(commandText, GetRewardParametersFromSQLReader);
		}

		private Reward GetRewardParametersFromSQLReader(SqlDataReader reader)
		{
			return new Reward
			(
				id: reader.GetInt32(0),
				title: reader[1].ToString(),
				description: reader[2].ToString()
			);
		}
	}
}
