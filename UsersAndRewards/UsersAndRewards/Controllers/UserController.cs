using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAndRewards.Models;
using UsersRewards.Common;
using UsersRewards.Common.Models;

namespace UsersAndRewards.Controllers 
{
    public class UserController: Controller
    {
        private readonly IStorage _storage;

        public UserController(IStorage storage)
        {
            _storage = storage;
        }

        //1
        public IActionResult Index()
        {
            IEnumerable<UserModel> users = _storage.GetUsersList();
            IEnumerable<UserViewModel> model = users.Select(u => u.ConvertToViewModel());
            return View(model);
        }

        //2
        [HttpGet]
        public IActionResult AddOrEdit(int id)
        {
            var user = new UserViewModel();
            if (id != 0) 
            {
                 if (_storage.UpdateUser(_storage.GetUsersList().FirstOrDefault(u => u.Id == id)) == null)
                 {
                        throw new ArgumentNullException(nameof(user));
                 }
                 else 
                    user = _storage.UpdateUser(_storage.GetUsersList().FirstOrDefault(u => u.Id == id)).ConvertToViewModel();
            }
                
            user.AllRewards = _storage.GetRewardsList().Select(r => r.ConvertToViewModel()).ToList();
            user.AllRewards.ForEach(u => u.Checked = false);
            if (id ==0)
                return View(user);
            user.AllRewards.Where(r => user.Rewards.Select(i => i.Id).Contains(r.Id)).All(m => m.Checked = true);
            return View(user);
        }


        [HttpPost]
        public IActionResult AddOrEdit(UserViewModel user)
        {
            
            if (user.Id == 0)
            {
                user.Rewards = (user.AllRewards.Where(r => r.Checked == true)).ToList();
                _storage.AddUser(user.ConvertToModel());

            }
            else
            { 
                foreach (var r in (user.AllRewards.Where(r => r.Checked == false)).ToList())
                    {
                        if (_storage.GetRewardsByUserId(user.Id).FirstOrDefault(u => u.Id == r.Id) != null)
                            _storage.RemoveReward(user.Id, r.Id);
                    }
                    foreach (var r in (user.AllRewards.Where(r => r.Checked == true)).ToList())
                    {
                        if (_storage.GetRewardsByUserId(user.Id).FirstOrDefault(u => u.Id == r.Id) == null)
                            _storage.RewardUser(user.Id, r.Id);
                    }
                
                _storage.UpdateUser(user.ConvertToModel());
            }
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            _storage.RemoveUserById(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
