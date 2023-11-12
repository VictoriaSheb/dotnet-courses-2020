using System;
using System.ComponentModel;

namespace Entities
{
    public class UserShort
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate;
        public string BirthdateShort 
        {
            get 
            {
                return Birthdate.ToShortDateString();
            }
        }
        public BindingList<Reward> RewardsUser { get; set; }
        public int Age
        {
            get
            {
                return CountYears(Birthdate);
            }
        }



        public UserShort(string firstName, string lastName, DateTime dateOfBirth)
        {
            this.Birthdate = CheckDate(dateOfBirth, 150);
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public UserShort(string firstName, string lastName, DateTime dateOfBirth, BindingList<Reward> rewards)
        {
            this.Birthdate = CheckDate(dateOfBirth, 150);
            this.FirstName = firstName;
            this.LastName = lastName;
            this.RewardsUser = rewards;
        }

        protected DateTime CheckDate(DateTime usedDate, int checkMaxNumberNotInclude)
        {
            DateTime date = DateTime.Now;
            if (usedDate > date || (date.Year - date.Year > checkMaxNumberNotInclude))
            {
                //значение аргумента вне диапозона допустимых
                throw new ArgumentOutOfRangeException($"{nameof(usedDate)}", $"Значение не возможно для текущей даты {date.ToShortDateString()} ");
            }
            else
                return usedDate;
        }

        protected int CountYears(DateTime usedDate)
        {
            DateTime date = DateTime.Now;
            int countYears = date.Year - usedDate.Year;
            countYears -= (((date.Month < usedDate.Month) || ((date.Month == usedDate.Month) && (date.Day < usedDate.Day))) ? 1 : 0);
            return countYears;
        }
    }

    public class User : UserShort
    {
        public int Id { get; }

        public User(int id, string firstName, string lastName, DateTime dateOfBirth) : base(firstName, lastName,  dateOfBirth)
        {
            this.Id = id;
        }

        public User(int id, string firstName, string lastName, DateTime dateOfBirth, BindingList<Reward> rewards) : base(firstName, lastName, dateOfBirth, rewards)
        {
            this.Id = id;
        }
        public User(int id, UserShort user ) : base(user.FirstName, user.LastName, user.Birthdate, user.RewardsUser)
        {
            this.Id = id;
        }
    }




 }
