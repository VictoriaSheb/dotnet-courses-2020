using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class User
    {
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime birthdate;
        public string BirthdateShort 
        {
            get 
            {
                return birthdate.ToShortDateString();
            }
        }
        public List<Reward> RewardsUser { get; set; }
        public int Age
        {
            get
            {
                return CountYears(birthdate);
            }
        }



        public User(int id, string firstName, string lastName, DateTime dateOfBirth)
        {
            this.Id = id;
            this.birthdate = CheckDate(dateOfBirth, 150);
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public User(int id, string firstName, string lastName, DateTime dateOfBirth, List<Reward> rewards)
        {
            this.Id = id;
            this.birthdate = CheckDate(dateOfBirth, 150);
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
}
