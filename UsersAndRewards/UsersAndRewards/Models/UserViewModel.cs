using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsersAndRewards.Models
{
    public class UserViewModel
    {
        public int Id { get; 
            set; }
        [Required]
        public string LastName   {get;set;}
        [Required]
        public string FirstName { get; 
            set; }
        [Required ]
        
        public DateTime BirthDate { get; 
            set; }
        [Required]
        public List<RewardViewModel> Rewards { get;
            set; }
        public List<RewardViewModel> AllRewards
        { get; set; }


        public UserViewModel()
        {
            Rewards = new List<RewardViewModel>();
            AllRewards = new List<RewardViewModel>();

        }
    }
}
