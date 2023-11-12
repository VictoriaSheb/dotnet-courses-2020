using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department.DAL.Interfaces
{
    public interface IUserDAO : IEntityDAO<User,UserShort>
    {
        void RemoveReward(Reward reward);

        BindingList<Reward> GetRewardsFromUser(int id);
    }
}
