using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAndRewards.Models;
using UsersRewards.Common;

namespace UsersAndRewards.Controllers
{
    public class RewardController : Controller
    {
        private readonly IStorage _storage;

        public RewardController(IStorage storage)
        {
            _storage = storage;
        }

        //3
        public IActionResult Index()
        {
            return View(_storage.GetRewardsList().Select(r => r.ConvertToViewModel()));
        }

        //4
        [HttpGet]
        public IActionResult AddOrEdit(int Id)
        {
            if (Id == 0)
                return View(new RewardViewModel());
            var reward = _storage.UpdateReward(_storage.GetRewardsList().FirstOrDefault(u => u.Id == Id)).ConvertToViewModel();
            if (reward == null) 
            {
                throw new ArgumentNullException(nameof(reward));
            }
            reward.Checked = false;
            return View(reward);
        }


        [HttpPost]
        public IActionResult AddOrEdit(RewardViewModel rewardModel)
        {
            if (rewardModel.Id == 0)
            {
                _storage.AddReward(rewardModel.ConvertToModel());
            }
            else
            {
                _storage.UpdateReward(rewardModel.ConvertToModel());
                foreach (var user in _storage.GetUsersList()) 
                {
                    _storage.UpdateUser(user);
                }
            }
            return RedirectToAction(nameof(Index));

        }
        
        public IActionResult Delete(int id)
        {
            _storage.RemoveRewardById(id);

            return RedirectToAction(nameof(Index));
        }



    }
}
