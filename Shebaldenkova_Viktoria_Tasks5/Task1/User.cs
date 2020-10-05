using System;

namespace Task1
{
    class User
    {
        public string firstName { get; }
        public string middleName { get; }
        public string lastName { get; }
        public DateTime dateOfBirth { get; }
        public int age
        {
            get
            {
                return GetAge();
            }
        }

        public User(string firstName, string middleName, string lastName, DateTime dateOfBirth)
        {
            this.dateOfBirth = dateOfBirth;
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;

        }

        private int GetAge()
        {
            DateTime date = DateTime.Now;
            int age = date.Year - dateOfBirth.Year;
            age-= (((date.Month < dateOfBirth.Month) || ((date.Month == dateOfBirth.Month) && (date.Day < dateOfBirth.Day))) ? 1 : 0);
            return age;
        }
       


    }
}
