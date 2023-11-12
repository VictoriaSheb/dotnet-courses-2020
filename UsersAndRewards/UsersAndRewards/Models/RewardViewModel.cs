using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersAndRewards.Models
{
    public class RewardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }

        public RewardViewModel()
        {
            Checked = false;
        }
    }
}
