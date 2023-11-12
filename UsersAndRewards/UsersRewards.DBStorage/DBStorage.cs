using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UsersRewards.Common;
using UsersRewards.Common.Models;

namespace UsersRewards.DBStorage
{
    public class DBStorage : IStorage
    {

        private string _connectionString;
        public DBStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddReward(RewardModel reward)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "INSERT INTO Rewards ( Name, Description) VALUES ( @Name, @Description)" +
                                          "SELECT MAX(Id) FROM Users";
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = reward.Name;
                    command.Parameters.Add("@Description", SqlDbType.Text).Value = reward.Description;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reward.Id = reader.GetInt32(0);
                        }
                    }
                    connection.Close();
                }
            }

            return reward.Id;
        }

        public int AddUser(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "INSERT INTO Users ( FirstName, LastName, BirthDate) VALUES ( @FirstName, @LastName, @BirthDate)" +
                                          "SELECT MAX(Id) FROM Users";
                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = user.FirstName;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = user.LastName;
                    command.Parameters.Add("@BirthDate", SqlDbType.Date).Value = user.BirthDate;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.Id = reader.GetInt32(0);
                        }
                    }
                    connection.Close();
                    foreach (var reward in user.Rewards) 
                    {
                        RewardUser(user.Id, reward.Id);
                    }
                    connection.Close();
                }
            }

            return user.Id;
        }

        public List<RewardModel> GetRewardsByUserId(int id)
        {
            List<RewardModel> rewards = new List<RewardModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT IdReward, Title, Description FROM Rewards INNER JOIN UserRewards ON Rewards.Id = UserRewards.IdReward WHERE IdUser = @id";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RewardModel model = new RewardModel();
                            model.Id = reader.GetInt32(0);
                            model.Name = reader[1].ToString();
                            model.Description = reader[2].ToString();
                            rewards.Add(model);
                        }

                    }
                    connection.Close();
                }
            }

            return rewards;

        }

        public List<RewardModel> GetRewardsList()
        {
            List<RewardModel> reward = new List<RewardModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Id, Title, Description  FROM Rewards";

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RewardModel model = new RewardModel()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader[1].ToString(),
                                Description = reader[2].ToString()
                            };
                            reward.Add(model);
                        }
                    }
                    connection.Close();
                }
            }
            return reward;
        }

        public List<UserModel> GetUsersList()
        {
            List<UserModel> User = new List<UserModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Id, FirstName, LastName, BirthDate  FROM Users";

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserModel model = new UserModel();
                            model.Id = reader.GetInt32(0);
                            model.FirstName = reader[1].ToString();
                            model.LastName = reader[2].ToString();
                            model.BirthDate = (DateTime)reader[3];
                            User.Add(model);
                        }
                    }
                    connection.Close();
                    foreach (var user in User)
                    {
                        user.Rewards = GetRewardsByUserId(user.Id);
                    }
                }
            }
            return User;
        }

        public bool RemoveReward(int userId, int rewardId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM UserRewards WHERE IdReward=@rewardId and IdUser=@userId";
                    command.Parameters.Add("@rewardId", SqlDbType.Int).Value = rewardId;
                    command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return true;
        }

        public bool RemoveRewardById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Rewards WHERE Id=@id";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return true;
        }

        public bool RemoveUserById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Users WHERE Id=@id";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return true;
        }

        public bool RewardUser(int userId, int rewardId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO UserRewards (IdUser, IdReward) VALUES (@IdUser, @IdReward)";
                    command.Parameters.Add("@IdReward", SqlDbType.Int).Value = rewardId;
                    command.Parameters.Add("@IdUser", SqlDbType.Int).Value = userId;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return true;
        }

        public RewardModel UpdateReward(RewardModel reward)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Rewards SET Name=@Name, Description=@Description FROM Rewards WHERE Id=@Id";
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = reward.Id;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = reward.Name;
                    command.Parameters.Add("@Description", SqlDbType.Text).Value = reward.Description;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return reward;
        }

        public UserModel UpdateUser(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Users SET FirstName=@FirstName, LastName=@LastName, BirthDate=@BirthDate  FROM Users WHERE Id=@Id";
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = user.Id;
                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = user.FirstName;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = user.LastName;
                    command.Parameters.Add("@BirthDate", SqlDbType.Date).Value = user.BirthDate;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return user;
        }
    }
}
