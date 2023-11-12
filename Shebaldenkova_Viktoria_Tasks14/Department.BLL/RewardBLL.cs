using Department.DAL;
using Entities;
using System;
using System.Collections.Generic;

namespace Department.BLL
{
    public class RewardBLL
    {
        private RewardDAO rewardsDAO;

        public RewardBLL()
        {
            rewardsDAO = new RewardDAO();
        }

        public IEnumerable<Reward> InitList()
        {
            foreach (Reward reward in DataList.rewards)
            {
                Add(reward);
            }

            return GetList();
        }

        public void Add(RewardShort reward)
        {
            rewardsDAO.Add(reward);
        }

        public void Remove(Reward rewards)
        {
            if (rewards == null)
                throw new ArgumentException("Не задан user");
            
            rewardsDAO.Remove(rewards);

        }

        public void Edit(Reward reward)
        {
            if (reward == null)
                throw new ArgumentException("Не задан user");
            rewardsDAO.Edit(reward);
        }

        public IEnumerable<Reward> GetList()
        {
            return rewardsDAO.GetList();
        }

        
    }
}
