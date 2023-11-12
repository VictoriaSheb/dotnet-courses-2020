using System;
using System.Collections.Generic;
using System.Text;
using UsersRewards.Common.Models;

namespace UsersRewards.Common
{
    public interface IStorage
    {
        int AddReward(RewardModel reward);
        int AddUser(UserModel user);
        bool RemoveRewardById(int id);
        bool RemoveUserById(int id);
        List<RewardModel> GetRewardsList();
        List<UserModel> GetUsersList();
        UserModel UpdateUser(UserModel user);
        RewardModel UpdateReward(RewardModel reward);
        List<RewardModel> GetRewardsByUserId(int id);
        bool RewardUser(int userId, int rewardId);
        bool RemoveReward(int userId, int rewardId);
    }
}
