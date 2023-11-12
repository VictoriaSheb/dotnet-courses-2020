using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RewardShort
    {
        public string Title { set; get; }
        public string Description { set; get; }

        public RewardShort(string title, string description) 
        {
            this.Title = title;
            this.Description = description;
        }

    }

    public class Reward : RewardShort
    {
        public int Id { get; }
        public Reward(int id, string title, string description) : base (title, description)
        {
            this.Id = id;
        }

        public Reward(int id, RewardShort reward) : base(reward.Title, reward.Description)
        {
            this.Id = id;
        }

    }

}
