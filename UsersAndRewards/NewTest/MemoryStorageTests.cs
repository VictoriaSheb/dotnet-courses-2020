using System;
using System.Collections.Generic;
using System.Linq;
using UsersRewards.Common.Models;
using Xunit;

namespace NewTest
{
    public class MemoryStorageTests
    {

        [Fact]
        public void GetAllRewardsNotNull()
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();

            //act
            var rewardList = storage.GetRewardsList();

            //assert
            Assert.NotNull(rewardList);

        }


        [Fact]
        public void GetAllUsersNotNull()
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();

            //act
            var userList = storage.GetUsersList();

            //assert
            Assert.NotNull(userList);

        }


        [Fact]
        public void AddFirstReward()
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();
            var expected = 1; 

            //act
            var actual = storage.AddReward(new RewardModel());
            
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddAnyReward()
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage(); 
            

            //act
            storage.AddReward(new RewardModel());
            var actual = storage.AddReward(new RewardModel());
            var expected = storage.GetRewardsList().Count;

            //assert
            Assert.Equal(expected, actual);
        }



        [Fact]
        public void AddFirstUser()
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();
            var expected = 1;

            //act
            var actual = storage.AddUser(new UserModel());

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddAnyUser()
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();


            //act
            storage.AddUser(new UserModel());
            var actual = storage.AddUser(new UserModel());
            var expected = storage.GetUsersList().Count;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetRewardsByUserNotExistsId() 
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();

            //act
            int idNotExists = 0;

            //assert
            Assert.Throws<System.InvalidOperationException>(() => storage.GetRewardsByUserId(idNotExists));
        }

        [Fact]
        public void GetRewardsByUserExistsId()
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();

            var reward = new RewardModel()
            {
                Name = "A",
                Description = "empty"
            };
            var user = new UserModel()
            {
                BirthDate = new DateTime(1999, 06, 07),
                FirstName = "Ivan",
                LastName = "Ivanov",
            };

            //act
            var idReward = storage.AddReward(reward);
            var idUser = storage.AddUser(user);
            storage.RewardUser(idUser, idReward);

            //assert
            Assert.NotNull(storage.GetRewardsByUserId(idUser));
        }


        [Fact]
        public void RemoveRewardByNotExistsId()
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();

            //act
            int idNotExists = 0;

            //assert
            Assert.False(storage.RemoveRewardById(idNotExists));

        }


        [Fact]
        public void RemoveRewardByIdRemoveRewardUser()
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();

            var reward = new RewardModel()
            {
                Name = "A",
                Description = "empty"
            };


            var user = new UserModel()
            {
                BirthDate = new DateTime(1999, 06, 07),
                FirstName = "Ivan",
                LastName = "Ivanov",
            };

            //act
            var idReward = storage.AddReward(reward);
            var idUser = storage.AddUser(user);
            storage.RewardUser(idUser, idReward);
            storage.RemoveRewardById(idReward);
           

            //asset
            Assert.Null(storage.GetRewardsList().FirstOrDefault(r => r.Id == idReward));
            Assert.Null(storage.GetUsersList().FirstOrDefault(u =>u.Id == idUser).Rewards.FirstOrDefault(r => r.Id == idReward));
        }

        [Fact]
        public void RemoveUserByNotExistsId() 
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();

            //act
            int idNotExists = 0;

            //assert
            Assert.False(storage.RemoveUserById(idNotExists));
        }

        [Fact]
        public void RemoveUserByExistsId()
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();
            var user = new UserModel()
            {
                BirthDate = new DateTime(1999, 06, 07),
                FirstName = "Ivan",
                LastName = "Ivanov",
            };

            //act
            var idUser = storage.AddUser(user);

            //assert
            Assert.True(storage.RemoveUserById(idUser));
        }

        [Fact]
        public void RewarUserdEmptyUserOrEmtyReward() 
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();

            var reward = new RewardModel()
            {
                Name = "A",
                Description = "empty"
            };
            var user = new UserModel()
            {
                BirthDate = new DateTime(1999, 06, 07),
                FirstName = "Ivan",
                LastName = "Ivanov",
            };
            int idDefaultReward = 0;
            int idDefaultUser = 0;


            //act
            var idReward = storage.AddReward(reward);
            bool resultUserFake = storage.RewardUser(idDefaultUser, idReward);

            var idUser = storage.AddUser(user);
            bool resultRewardFake =  storage.RewardUser(idUser, idDefaultReward);

            //assert
            Assert.False(resultUserFake);
            Assert.False(resultRewardFake);


        }


        [Fact]
        public void RewardUserTrueUserAndReward()
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();

            var reward = new RewardModel()
            {
                Name = "A",
                Description = "empty"
            };
            var user = new UserModel()
            {
                BirthDate = new DateTime(1999, 06, 07),
                FirstName = "Ivan",
                LastName = "Ivanov",
            };

            //act

            //assert
            Assert.True(storage.RewardUser(storage.AddUser(user), storage.AddReward(reward)));
        }

        [Fact]
        public void RemoveRewardEmptyUserOrEmtyReward()
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();

            var reward = new RewardModel()
            {
                Name = "A",
                Description = "empty"
            };
            var user = new UserModel()
            {
                BirthDate = new DateTime(1999, 06, 07),
                FirstName = "Ivan",
                LastName = "Ivanov",
            };
            int idDefaultReward = 0;
            int idDefaultUser = 0;


            //act
            var idReward = storage.AddReward(reward);
            bool resultUserFake = storage.RemoveReward(idDefaultUser, idReward);

            var idUser = storage.AddUser(user);
            bool resultRewardFake = storage.RemoveReward(idUser, idDefaultReward);

            //assert
            Assert.False(resultUserFake);
            Assert.False(resultRewardFake);


        }


        [Fact]
        public void RemoveRewardTrueUserAndReward()
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();

            var reward = new RewardModel()
            {
                Name = "A",
                Description = "empty"
            };
            var user = new UserModel()
            {
                BirthDate = new DateTime(1999, 06, 07),
                FirstName = "Ivan",
                LastName = "Ivanov",
            };

            //act
            var idReward = storage.AddReward(reward);
            var idUser = storage.AddUser(user);
            storage.RewardUser(idUser, idReward);
            //assert

            Assert.True(storage.RemoveReward(idUser,idReward));
        }


        [Fact]
        public void UpdateRewardTrue() 
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();

            var reward = new RewardModel()
            {
                Name = "A",
                Description = "empty"
            };
            var rewardUpd = new RewardModel()
            {
                Id = 1,
                Name = "B",
                Description = "neempty"
            };

            //Act
            storage.AddReward(reward);
            var result = storage.UpdateReward(rewardUpd);

            //Assert
            Assert.Equal(result.Name, rewardUpd.Name);
            Assert.Equal(result.Description, rewardUpd.Description);

        }

        [Fact]
        public void UpdateRewardNotExists() 
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();

            //Act

            //Assert
            Assert.Null(storage.UpdateReward(new RewardModel()));
        }


        [Fact]
        public void ReturnEqualRewardUpdate()
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();

            var reward = new RewardModel()
            {
                Name="A",
                Description="empty"
            };

            var rewardEdit = new RewardModel()
            {
               Id = 1,
                Name = "A",
                Description = "empty"
            };

            var user = new UserModel()
            {
                BirthDate = new DateTime(1999, 06, 07),
                FirstName = "Ivan",
                LastName = "Ivanov",
            };

            //Act
            var idUser = storage.AddUser(user);
            var idReward = storage.AddReward(reward);
            storage.RewardUser(idUser, idReward);
            storage.UpdateReward(rewardEdit);

            //Assert
            Assert.Equal(storage.GetUsersList().FirstOrDefault(u => u.Id == idUser).Rewards.FirstOrDefault(u => u.Id == idReward).Name, reward.Name);
        }


        [Fact]
        public void UpdateUserTrue() 
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();

            var user = new UserModel()
            {
                FirstName = "A",
                LastName = "B",
                BirthDate = new DateTime(1999,08,09)
            };
            var userUpd = new UserModel()
            {
                Id = 1,
                FirstName = "C",
                LastName = "D",
                BirthDate = new DateTime(1999, 09, 09)
            };

            //Act
            storage.AddUser(user);
            var result = storage.UpdateUser(userUpd);

            //Assert
            Assert.Equal(result.FirstName, userUpd.FirstName);
            Assert.Equal(result.LastName, userUpd.LastName);
            Assert.Equal(result.BirthDate, userUpd.BirthDate);


        }


        [Fact]
        public void UpdateUserNotExists() 
        {
            //Arrange
            UsersRewards.MemoryStorage.MemoryStorage storage = new UsersRewards.MemoryStorage.MemoryStorage();

            //Act

            //Assert
            Assert.Null(storage.UpdateUser(new UserModel()));

        }


    }
}
