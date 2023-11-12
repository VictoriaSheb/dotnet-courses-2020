using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAndRewards.Models;
using UsersRewards.Common.Models;

namespace UsersAndRewards
{
    public static class Converter
    {
        public static RewardViewModel ConvertToViewModel(this RewardModel domainModel)
        {
            return new RewardViewModel()
            {
                Id = domainModel.Id,
                Description = domainModel.Description,
                Name = domainModel.Name
            };
        }

        public static RewardModel ConvertToModel(this RewardViewModel viewModel)
        {
            return new RewardModel()
            {
                Id = viewModel.Id,
                Description = viewModel.Description,
                Name = viewModel.Name
            };
        }


        public static UserViewModel ConvertToViewModel(this UserModel domainModel)
        {
            UserViewModel userView = new UserViewModel();
            userView.Id = domainModel.Id;
            userView.FirstName = domainModel.FirstName;
            userView.LastName = domainModel.LastName;
            userView.BirthDate = domainModel.BirthDate;
            userView.Rewards = domainModel.Rewards.Select(r => r.ConvertToViewModel()).ToList();
            return userView;


        }

        public static UserModel ConvertToModel(this UserViewModel viewModel)
        {
            UserModel user = new UserModel();
            user.Id = viewModel.Id;
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.BirthDate = viewModel.BirthDate;
            user.Rewards = viewModel.Rewards.Select(r => r.ConvertToModel()).ToList();
            return user;

        }


    }
}
