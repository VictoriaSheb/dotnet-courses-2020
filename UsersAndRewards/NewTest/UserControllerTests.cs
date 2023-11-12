using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersAndRewards.Controllers;
using UsersAndRewards.Models;
using UsersRewards.Common;
using UsersRewards.Common.Models;
using Xunit;

namespace UsersRewards.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public void ReturnNotNull()
        {
            //Arrange
            var mockedStorage = new Mock<IStorage>();
            var users = new List<UserModel>
            {
                new UserModel {Id = 1, FirstName="A", LastName="B", BirthDate=new DateTime(1999,07,07)  },
                new UserModel {Id = 2, FirstName="C", LastName="D", BirthDate=new DateTime(1999,07,07)  },

            };
            //var rewards = new List<RewardModel>
            //{
            //    new RewardModel {Id = 1, Name="E", Description="gbfgvfd"  },
            //    new RewardModel {Id = 2, Name="F", Description="gbfgvfd"  },

            //};

            mockedStorage.Setup(x => x.GetUsersList()).Returns(users);
            var controller = new UserController(mockedStorage.Object);

            //Act
            ViewResult result = (ViewResult)controller.Index();
            IEnumerable<UserViewModel> model = (IEnumerable<UserViewModel>)result.Model;

            //Assert
            Assert.Equal(model.Count(), users.Count());
        }



        [Fact]
        public void EditCheckedAndOtherParametrs()
        {
            //Arrange
            var mockedStorage = new Mock<IStorage>();
            var rewards = new List<RewardModel>
            {
                new RewardModel {Id = 1, Name="E", Description="gbfgvfd"  },
                new RewardModel {Id = 2, Name="F", Description="gbfgvfd"  },

            };

            var users = new List<UserModel>
            {
                new UserModel {Id = 1, FirstName="A", LastName="B", BirthDate=new DateTime(1999,07,07), Rewards={rewards[0] }  },
                new UserModel {Id = 2, FirstName="C", LastName="D", BirthDate=new DateTime(1999,07,07)  },

            };

            mockedStorage.Setup(x => x.GetUsersList()).Returns(users);
            mockedStorage.Setup(x => x.GetRewardsList()).Returns(rewards);
            mockedStorage.Setup(x => x.UpdateUser(It.IsAny<UserModel>())).Returns(users[0]);

            var controller = new UserController(mockedStorage.Object);

            //Act
            ViewResult result = (ViewResult)controller.AddOrEdit(1);
            UserViewModel model = (UserViewModel)result.Model;

            //Assert
            Assert.True(model.AllRewards[0].Checked);
            Assert.False(model.AllRewards[1].Checked);
            Assert.Equal(model.FirstName, users[0].FirstName);
            Assert.Equal(model.LastName, users[0].LastName);
            Assert.Equal(model.BirthDate, users[0].BirthDate);
        }


        [Fact]
        public void AddCheckedAndOtherParametrs()
        {
            //Arrange
            var mockedStorage = new Mock<IStorage>();
            mockedStorage.Setup(x => x.GetRewardsList()).Returns(new List<RewardModel>());
            var controller = new UserController(mockedStorage.Object);

            //Act
            ViewResult result = (ViewResult)controller.AddOrEdit(0);
            UserViewModel model = (UserViewModel)result.Model;

            //Assert
            Assert.NotNull(model);
        }


        [Fact]
        public void AddOrEditNotExists()
        {
            //Arrange
            var mockedStorage = new Mock<IStorage>();
            mockedStorage.Setup(x => x.GetRewardsList()).Returns(new List<RewardModel>());
            mockedStorage.Setup(x => x.GetUsersList()).Returns(new List<UserModel>());
            mockedStorage.Setup(x => x.UpdateUser(null)).Returns((UserModel)null);
            var controller = new UserController(mockedStorage.Object);

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => (ViewResult)controller.AddOrEdit(5));

        }


    }
}