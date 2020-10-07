using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //      UserService userService = new UserService();
            //   user.AddNewUser("Иван","Иванович", "Иванов", new DateTime(2000,1,1));
            //      userService.AddNewUser();
            //      userService.LookInformationAboutUser();

            Employee employee = new Employee("Иван", "Иванович", "Иванов", new DateTime(1980, 1, 1),"Юрист", new DateTime(2002, 1, 1));
            employee.StatusEmployee = false;
            EmployeeService employeeService = new EmployeeService(employee);
            employeeService.LookInformation();
        }
    }
}
