using System;
using System.Collections.Generic;
using System.Linq;
using UsersRewards.Common;
using UsersRewards.Common.Models;

namespace UsersRewards.MemoryStorage
{
    public class MemoryStorage : IStorage
    {
        //public static List<RewardViewModel> RewardsList = new List<RewardViewModel>
        //{
        //    new RewardViewModel{ Id=1, Name="Золотая медаль", Description="За первое место" },
        //    new RewardViewModel{ Id=2, Name="Серебряная медаль", Description="За второе место" },
        //    new RewardViewModel{ Id=3, Name="Бронзовая медаль", Description="За третье место" },
        //    new RewardViewModel{ Id=4, Name="Приз недели", Description="За активную работу на неделе" },
        //    new RewardViewModel{ Id=5, Name="Приз лета", Description="Награда за летние события" },
        //};

        //public static List<UserViewModel> UsersList = new List<UserViewModel>
        //{
        //    new UserViewModel{ Id=1, LastName="Игрок1", FirstName="Игрок1" , BirthDate="12/12/1999" ,
        //    Rewards= new  List<RewardViewModel>{ RewardsList[0] , RewardsList[1],RewardsList[4]}
        //    },
        //    new UserViewModel{ Id=2, LastName="Игрок2",  FirstName="Игрок2" , BirthDate="24/12/1999" ,
        //    Rewards= new List<RewardViewModel>{ RewardsList[2] }
        //    },
        //    new UserViewModel{ Id=3, LastName="Игрок3",  FirstName="Игрок3", BirthDate="05/03/1999" ,
        //    Rewards= new List<RewardViewModel>{ RewardsList[3], RewardsList[4]}
        //    },
        //};

        List<RewardModel> RewardsList = new List<RewardModel>();
        List<UserModel> UsersList = new List<UserModel>();
        //добавить
        public int AddReward(RewardModel reward)
        {
            if (RewardsList.Count == 0)
                reward.Id = 1;
            else
                reward.Id = RewardsList.Max(m => m.Id) + 1;
            RewardsList.Add(reward);
            return reward.Id;
        }

        public int AddUser(UserModel user)
        {
            if (UsersList.Count == 0)
                user.Id = 1;
            else
                user.Id = UsersList.Max(m => m.Id) + 1;
            UsersList.Add(user);
            return user.Id;
        }

        //получить награды по Id пользователя
        public List<RewardModel> GetRewardsByUserId(int id)
        {
            var user = UsersList.First(r => r.Id == id);
            return user.Rewards;
        }

        //получить весь список 
        public List<RewardModel> GetRewardsList()
        {
            if (RewardsList.Count == 0)
            {
                return new List<RewardModel>();
            }
            return RewardsList;
        }

        public List<UserModel> GetUsersList()
        {
            if (UsersList.Count == 0)
                return new List<UserModel>();
            return UsersList;
        }


        public bool RemoveRewardById(int id)
        {
            if (RewardsList.FirstOrDefault(r => r.Id == id) == null)
                return false;
            ////удаление награды у клиента
            var rewardList = new List<RewardModel>();

            for (int k = 0; k < UsersList.Count; k++)
            {
                for (int x = 0; x < UsersList[k].Rewards.Count; x++)
                {
                    if (UsersList[k].Rewards[x].Id != id)
                        rewardList.Add(UsersList[k].Rewards[x]);
                }

                UsersList[k].Rewards.Clear();
                foreach (var reward in rewardList)
                {
                    UsersList[k].Rewards.Add(reward);
                }
                rewardList.Clear();

            }
            //основное удаление
            RewardModel rewardRemove = RewardsList.FirstOrDefault(r => r.Id == id);
            if (rewardRemove == null)
                return false;
            RewardsList.Select(model => (model.Id > id) ? model.Id-- : model.Id);
            return RewardsList.Remove(rewardRemove);
        }



        //удалить пользователя по id
        public bool RemoveUserById(int id)
        {
            UserModel userRemove = UsersList.FirstOrDefault(r => r.Id == id);
            if (userRemove == null)
                return false;
            UsersList.Remove(userRemove);
            UsersList.Where(r => r.Id > id).ToList().Select(u => u.Id--);

            return true;
        }


        //удалить награду у пользователя
        public bool RemoveReward(int userId, int rewardId)
        {
            RewardModel rewardRemove = RewardsList.FirstOrDefault(r => r.Id == rewardId);
            if (rewardRemove == null)
                return false;
            if (UsersList.FirstOrDefault(u => u.Id == userId) == null)
                return false;
            return UsersList.FirstOrDefault(r => r.Id == userId).Rewards.Remove(rewardRemove);

        }

        //добавить награду пользователю
        public bool RewardUser(int userId, int rewardId)
        {
            RewardModel reward = RewardsList.FirstOrDefault(r => r.Id == rewardId);
            if (reward == null)
                return false;
            if (UsersList.FirstOrDefault(u => u.Id == userId) == null)
                return false;
            UsersList.FirstOrDefault(u => u.Id == userId).Rewards.Add(reward);
            return true;
        }

        //обновить 
        public RewardModel UpdateReward(RewardModel reward)
        {
            RewardModel rewardUp = RewardsList.FirstOrDefault(re => re.Id == reward.Id);
            if (rewardUp == null)
                return null;
            rewardUp.Name = reward.Name;
            rewardUp.Description = reward.Description;
            return rewardUp;
        }

        public UserModel UpdateUser(UserModel user)
        {
            UserModel userUpdate = UsersList.FirstOrDefault(us => us.Id == user.Id);
            if (userUpdate == null)
                return null;
            userUpdate.FirstName = user.FirstName;
            userUpdate.LastName = user.LastName;
            userUpdate.BirthDate = user.BirthDate;
            return userUpdate;
        }

    }
}
