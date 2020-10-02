using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class User
    {
        public string firstName { set; get; }
        public string middleName { set; get; }
        public string lastName { set; get; }
        public DateTime dateOfBirth { set; get; }
        public int age {
            get 
            {
                DateTime date = DateTime.Now;
                return (date.Year - dateOfBirth.Year) - (((date.Month < dateOfBirth.Month) || ((date.Month == dateOfBirth.Month) && (date.Day < dateOfBirth.Day))) ? 1 : 0);
            } 
        }

        public User(string firstName, string middleName, string lastName, DateTime dateOfBirth) 
        {
            while (dateOfBirth > DateTime.Now || (DateTime.Now.Year - dateOfBirth.Year > 120)) 
            {
                Console.WriteLine("Введенная дата рождения не возможна или не является датой, введите верную дату:");
                CheckDate(Console.ReadLine(), ref dateOfBirth);
            }
            this.dateOfBirth = dateOfBirth; 
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;

        }

        public User() 
        {
            Console.WriteLine("Заполнение данных пользователя:");
            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine();
            Console.Write("Введите отчество: ");
            string middleName = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите дату рождения в формате dd.MM.yyyy:");
            string dateOfBirthString = Console.ReadLine();
            DateTime dateOfBirth = default;
            while ((!CheckDate(dateOfBirthString, ref dateOfBirth)) || (dateOfBirth > DateTime.Now) || (DateTime.Now.Year-dateOfBirth.Year>120))
            {
                Console.WriteLine("Введенная дата рождения не возможна или не является датой, введите верную дату:");
                CheckDate(dateOfBirthString=Console.ReadLine(), ref dateOfBirth);
            }

            this.dateOfBirth = dateOfBirth;
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
        }


        private bool CheckDate(string dateString, ref DateTime date)
        {
            if (DateTime.TryParse(dateString, out date))
            {
                return true;
            }
            else
                return false;
        }

        public void LookInformationAboutUser() 
        {
            Console.WriteLine("Данные пользователя:");
            Console.WriteLine("Имя: "+ this.firstName);
            Console.WriteLine("Отчество: "+this.middleName);
            Console.WriteLine("Фамилия:"+this.lastName);
            Console.WriteLine("Дата рождения: "+this.dateOfBirth.ToShortDateString());
            Console.WriteLine("Возраст: " + this.age);
            Console.ReadLine();
        }

    }
}
