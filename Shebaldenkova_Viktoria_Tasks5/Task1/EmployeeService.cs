using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class EmployeeService : UserService
    {
        Employee ThisEmployee;

        public EmployeeService(Employee employee) 
        {
            this.ThisEmployee = employee;
        }
        public Employee AddNewEmployee(Employee employee)
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
            Console.Write("Должность:");
            string position = Console.ReadLine();
            Console.Write("Дату заключения трудового договора:");
            string startWorkString = Console.ReadLine();
            return employee = new Employee(firstName, middleName, lastName, CheckDate(dateOfBirthString), position, CheckDate(startWorkString));
        }

        private DateTime CheckDate(string dateInputString) 
        {
            if (DateTime.TryParse(dateInputString, out DateTime dateInput))
                return dateInput;
            else
                throw new InvalidCastException($"{nameof(dateInputString)} не дата");
        }

        public override void  LookInformation()
        {
            Console.WriteLine("Данные пользователя:");
            Console.WriteLine("Имя: " + ThisEmployee.FirstName);
            Console.WriteLine("Отчество: " + ThisEmployee.MiddleName);
            Console.WriteLine("Фамилия:" + ThisEmployee.LastName);
            Console.WriteLine("Дата рождения: " + ThisEmployee.DateOfBirth.ToShortDateString());
            Console.WriteLine("Возраст: " + ThisEmployee.Age);
            Console.WriteLine("Должность:" + ThisEmployee.Position);
            Console.WriteLine("Дата заключения трудового договора:" + ThisEmployee.DateStartWork.ToShortDateString());
            if (ThisEmployee.StatusEmployee==false)
                Console.WriteLine("Дата расторжения трудового договора:" + ((DateTime)ThisEmployee.DateEndWork).ToShortDateString());
            Console.WriteLine("Стаж:" + ThisEmployee.WorkExperience+ "года(лет)");
            Console.ReadLine();
        }


    }
}
