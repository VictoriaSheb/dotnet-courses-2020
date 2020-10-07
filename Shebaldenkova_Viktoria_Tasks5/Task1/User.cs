using System;

namespace Task1
{
    class User
    {
        public string FirstName { set; get; }
        public string MiddleName { get; }
        public string LastName { set;  get; }
        public DateTime DateOfBirth { get; }
        public int Age
        {
            get
            {
                return CountYears(DateOfBirth);
            }
        }

        public User(string firstName, string middleName, string lastName, DateTime dateOfBirth)
        {
            this.DateOfBirth = CheckDate(dateOfBirth,109); 
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;
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
            countYears-= (((date.Month < usedDate.Month) || ((date.Month == usedDate.Month) && (date.Day < usedDate.Day))) ? 1 : 0);
            return countYears;
        }

        //public void ChangeFirstName(string newFirstName)
        //{
        //    this.FirstName = newFirstName;
        //}

        //public void ChangeLastName(string newLastName)
        //{
        //    this.LastName = newLastName;
        //}




    }
}
