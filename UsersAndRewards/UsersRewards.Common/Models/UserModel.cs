using System;
using System.Collections.Generic;
using System.Text;

namespace UsersRewards.Common.Models
{
    public class UserModel
    {
        public int Id  {get;set; }

        public string LastName { get; set; }
        
        public string FirstName { get;set;}
      
        public DateTime BirthDate { get; set; }

        public List<RewardModel> Rewards { get; set; }

        public UserModel()
        {
            Rewards = new List<RewardModel>();
        }
       
        
    }
}
