using System;
using System.Collections.Generic;
using System.Linq;
using Department.DAL;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Department.DAL.Interfaces;
using System.ComponentModel;

namespace Department.BLL
{
    public class UserBLL
    {
		private IUserDAO usersDAO ;

		public UserBLL()
		{
            usersDAO = Config.GetDataSourceForUser();
		}

		public IEnumerable<User> InitList()
		{
			//foreach (User user in DataList.users) 
			//{
			//	Add(user);
			//}

			return GetList();
		}


		public void Add(UserShort user)
		{
			usersDAO.Add(user);
		}

		public void Remove(User user) 
		{
			if (user == null)
				throw new ArgumentException("Не задан user");
			usersDAO.Remove(user);
		}

		public void RemoveReward(Reward reward)
		{
			if (reward == null)
				throw new ArgumentException("Не задан user");
			usersDAO.RemoveReward(reward);
		}

		public void Edit(User user)
		{
			if (user == null)
				throw new ArgumentException("Не задан user");
			usersDAO.Edit(user);
		}

		public IEnumerable<User> GetList()
		{
			return usersDAO.GetList();
		}


		public BindingList<Reward> GetRewardsFromUser(int id)
		{
			return usersDAO.GetRewardsFromUser(id);
		}


	}
}
