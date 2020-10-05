using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class UserService
    {
        public User user;

        public void AddNewUser(string firstName, string middleName, string lastName, DateTime dateOfBirth) 
        {
            DateTime date = DateTime.Now;
            if (dateOfBirth > date || (date.Year - date.Year > 120))
            {
                //значение аргумента вне диапозона допустимых
                throw new ArgumentOutOfRangeException($"{nameof(dateOfBirth)}", $"Значение не возможно для текущей даты {date.ToShortDateString()} ");
            }
            else 
            {
                this.user = new User(firstName, middleName, lastName, dateOfBirth);
            }
        }

        public void AddNewUser() 
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
            try
            {
                DateTime dateOfBirth = DateTime.Parse(dateOfBirthString);
                AddNewUser(firstName, middleName, lastName, dateOfBirth);
            }
            catch(FormatException)
            {
                throw new InvalidCastException($"{nameof(dateOfBirthString)} не дата");

            }
        }

        public void LookInformationAboutUser()
        {
            Console.WriteLine("Данные пользователя:");
            Console.WriteLine("Имя: " + user.firstName);
            Console.WriteLine("Отчество: " + user.middleName);
            Console.WriteLine("Фамилия:" + user.lastName);
            Console.WriteLine("Дата рождения: " + user.dateOfBirth.ToShortDateString());
            Console.WriteLine("Возраст: " + user.age);
            Console.ReadLine();
        }

    }
}
