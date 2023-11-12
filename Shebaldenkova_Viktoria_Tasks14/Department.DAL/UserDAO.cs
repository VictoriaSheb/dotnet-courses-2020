using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Department.DAL
{
	public class UserDAO
	{
		private BindingList<User> users = new BindingList<User>();
		private int newId;

		public int Count 
		{
			get 
			{
				return users.Count;
			}
		}

		public void Add(UserShort user)
		{
			newId++;
			if (user == null)
				throw new ArgumentException("Не задан user");

			users.Add(new User(newId, user));
		}

		public void Edit(User user)
		{
			if (user == null)
				throw new ArgumentException("Не задан user");
			for (int i = 0; i < users.Count; i++)
			{
				if (users[i].Id == user.Id)
				{
					users[i] = user;
				}
			}
		}

		public void Remove(User user) 
		{
			if (user == null)
				throw new ArgumentException("Не задан user");
			if (users.First(u => u.Equals(user)) != null)
				users.Remove(user);
			else
				throw new ArgumentException("Удаляемый user не существует");
		}

		public void RemoveReward(Reward reward) 
		{
			if (reward == null)
				throw new ArgumentException("Не задан reward");
			for (int i = 0; i < users.Count; i++)
			{
				if (users[i].RewardsUser != null)
					for (int j = 0; j < users[i].RewardsUser.Count; j++)
					{
						if (users[i].RewardsUser[j].Id == reward.Id)
						{
							users[i].RewardsUser.Remove(reward);
							break;
						}
					}
			}
		}

		public IEnumerable<User> GetList()
        {
            return users;
        }

  //      public IEnumerable<User> GetList<User>()
  //      {
		//	return (IEnumerable<User>)users;
		//}
    }
}
