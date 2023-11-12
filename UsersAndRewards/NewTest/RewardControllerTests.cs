using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UsersAndRewards.Controllers;
using UsersAndRewards.Models;
using UsersRewards.Common;
using UsersRewards.Common.Models;
using Xunit;

namespace UsersRewards.Tests
{
    public class RewardControllerTests
    {
        [Fact]
        public void IndexNotNull()
        {
            //Arrange
            var mockedStorage = new Mock<IStorage>();
            var item = new List<RewardModel>
            {
                new RewardModel {Id = 1, Name="A", Description="gbfgvfd"  },
                new RewardModel {Id = 2, Name="B", Description="gbfgvfd"  },

            };

            mockedStorage.Setup(x => x.GetRewardsList()).Returns(item);
             var controller = new RewardController(mockedStorage.Object);

            //Act
            ViewResult result = (ViewResult)controller.Index();
            IEnumerable<RewardViewModel> model = (IEnumerable<RewardViewModel>)result.Model;

            //Assert
            Assert.Equal(model.Count(),item.Count());

        }

        [Fact]
        public void AddOrEdit()
        {
            //Arrange
            var mockedStorage = new Mock<IStorage>();
            var item = new RewardModel { Id = 1, Name = "A", Description = "gbfgvfd" };
            var items = new List<RewardModel> { item };
            mockedStorage.Setup(x => x.GetRewardsList()).Returns(items);
            mockedStorage.Setup(x => x.UpdateReward(It.IsAny<RewardModel>())).Returns(item);
            var controller = new RewardController(mockedStorage.Object);


            //Act
            ViewResult resultAdd = (ViewResult)controller.AddOrEdit(0);
            ViewResult resultEdit = (ViewResult)controller.AddOrEdit(1);
            RewardViewModel modelAdd = (RewardViewModel)resultAdd.Model;
            RewardViewModel modelEdit = (RewardViewModel)resultEdit.Model;

            //Assert
            Assert.NotNull(modelAdd);
            Assert.NotNull(modelEdit);

        }



        [Fact]
        public void AddOrEditNotExists()
        {
            //Arrange
            var mockedStorage = new Mock<IStorage>();
            var controller = new RewardController(mockedStorage.Object);

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => (ViewResult)controller.AddOrEdit(5));

        }



    }
}
