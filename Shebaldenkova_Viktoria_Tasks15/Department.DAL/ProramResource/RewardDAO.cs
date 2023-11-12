using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Department.DAL
{
    public class RewardDAO : IEntityDAO<Reward, RewardShort>
    {
        private BindingList<Reward> rewards = new BindingList<Reward>();
        private int newId;

        public void Add(RewardShort reward)
        {
            newId++;
            if (reward == null)
                throw new ArgumentException("Не все аргументы заданы");
            rewards.Add(new Reward(newId, reward));
        }

        public void Remove(Reward reward)
        {
            if (reward == null)
                throw new ArgumentException("Не задана reward");
            if (rewards.First(u => u.Equals(reward)) != null)
            {
                rewards.Remove(reward);
            }

        }

        public void Edit(Reward reward)
        {
            for (int i = 0; i < rewards.Count; i++)
            {
                if (rewards[i].Id == reward.Id)
                {
                    rewards[i] = reward;
                }
            }
        }


        public IEnumerable<Reward> GetList()
        {
            return rewards;
        }
    }
}
