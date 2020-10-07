using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class UserService
    {
        private User user;

        public UserService(User user)
        {
            this.user = user;
        }

        protected UserService() { }

        public User ReturnUser() 
        {
            return user;
        }


        public User AddNewUser() 
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
                return user = new User(firstName, middleName, lastName, dateOfBirth);
            }
            catch(FormatException)
            {
                throw new InvalidCastException($"{nameof(dateOfBirthString)} не дата");

            }
        }

        public virtual void LookInformation()
        {
            Console.WriteLine("Данные пользователя:");
            Console.WriteLine("Имя: " + user.FirstName);
            Console.WriteLine("Отчество: " + user.MiddleName);
            Console.WriteLine("Фамилия:" + user.LastName);
            Console.WriteLine("Дата рождения: " + user.DateOfBirth.ToShortDateString());
            Console.WriteLine("Возраст: " + user.Age);
            Console.ReadLine();
        }

    }
}
