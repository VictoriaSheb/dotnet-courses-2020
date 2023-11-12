using Department.DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace Department.DAL.BD
{
	public class UserSqlDAO : IUserDAO
	{
		SQLService serviceSQL;

		public UserSqlDAO()
		{
			serviceSQL = new SQLService();
		}

		public void Add(UserShort user)
		{
			SqlParameter[] values = new SqlParameter[3];
			(values[0] = new SqlParameter("@FirstName", SqlDbType.NVarChar)).Value = user.FirstName;
			(values[1] = new SqlParameter("@LastName", SqlDbType.NVarChar)).Value = user.LastName;
			(values[2] = new SqlParameter("@BirthDate", SqlDbType.Date)).Value = user.Birthdate;
			serviceSQL.OperationChangeInBD("AddUser", values);
			int id = GetMaxIdUser();
			foreach (Reward reward in user.RewardsUser)
			{
				EditRewardFromUser(id, reward);
			}

		}

		public void Remove(User user)
		{
			SqlParameter[] values = new SqlParameter[1];
			(values[0] = new SqlParameter("@Id", SqlDbType.Int)).Value = user.Id;
			serviceSQL.OperationChangeInBD("RemoveUserById", values);
			//foreach (Reward reward in user.RewardsUser);
		}

		public void Edit(User user)
		{
			SqlParameter[] values = new SqlParameter[4];
			(values[0] = new SqlParameter("@Id", SqlDbType.Int)).Value = user.Id;
			(values[1] = new SqlParameter("@FirstName", SqlDbType.NVarChar)).Value = user.FirstName;
			(values[2] = new SqlParameter("@LastName", SqlDbType.NVarChar)).Value = user.LastName;
			(values[3] = new SqlParameter("@BirthDate", SqlDbType.Date)).Value = user.Birthdate;
			serviceSQL.OperationChangeInBD("UpdateUser", values);
			BindingList<Reward> userRewardsOld = GetRewardsFromUser(user.Id);
			EditNewOrRemoveOldRewardsFromUser(user.Id, user.RewardsUser, userRewardsOld, EditRewardFromUser);
			EditNewOrRemoveOldRewardsFromUser(user.Id,  userRewardsOld,user.RewardsUser, RemoveRewardFromUser);
		}

		private void EditNewOrRemoveOldRewardsFromUser(int userId, BindingList<Reward> rewardsMain,
			BindingList<Reward> rewardsRelative, Action<int, Reward> action) 
		{
			bool includes = false;
			foreach (Reward rewardMain in rewardsMain)
			{
				includes = false;
				foreach (Reward rewardRelative in rewardsRelative)
				{
					if (rewardMain.Id == rewardRelative.Id)
					{
						includes = true;
						break;
					}
				}
				if (includes == false) 
				{
					action(userId, rewardMain);
				}
			}
		}


		private void EditRewardFromUser(int userId, Reward reward)
		{
			SqlParameter[] values = new SqlParameter[2];
			(values[0] = new SqlParameter("@IdReward", SqlDbType.Int)).Value = reward.Id;
			(values[1] = new SqlParameter("@IdUser", SqlDbType.Int)).Value = userId;
			serviceSQL.OperationChangeInBD("AddUserHisReward", values);
		}

		private void RemoveRewardFromUser(int userId, Reward reward)
		{
			SqlParameter[] values = new SqlParameter[2];
			(values[0] = new SqlParameter("@IdReward", SqlDbType.Int)).Value = reward.Id;
			(values[1] = new SqlParameter("@IdUser", SqlDbType.Int)).Value = userId;
			serviceSQL.OperationChangeInBD("RemoveRewardFromUser", values);
		}


		public IEnumerable<User> GetList()
		{
			string commandText = "SELECT Id, FirstName, LastName, BirthDate  FROM Users";
			BindingList<User> users =  serviceSQL.OperationReadInBD(commandText, GetUserParametersFromSQLReader);
			for (int i=0; i < users.Count; i++) 
			{
				users[i].RewardsUser = GetRewardsFromUser(users[i].Id);
			}
			return users;
		}


		public BindingList<Reward> GetRewardsFromUser(int id)
		{
			string commandText = "SELECT IdReward, Title, Description " +
								 "FROM Rewards INNER JOIN UserRewards ON Rewards.Id = UserRewards.IdReward " +
								 "WHERE IdUser = @id";
			SqlParameter[] values = new SqlParameter[1];
			(values[0] = new SqlParameter("@Id", SqlDbType.Int)).Value = id;
			return serviceSQL.OperationReadInBD(commandText, values, GetRewardParametersFromSQLReader);
		}


		private int GetMaxIdUser()
		{
			string commandText = "SELECT MAX(Id) FROM Users";
			return serviceSQL.OperationReadInBD(commandText);
		}

		private User GetUserParametersFromSQLReader(SqlDataReader reader)
		{
			return new User
			(
				id: reader.GetInt32(0),
				firstName: reader[1].ToString(),
				lastName: reader[2].ToString(),
				dateOfBirth: (DateTime)reader[3]
			);
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

        public void RemoveReward(Reward reward)
        {
			return;
        }

    }
}
