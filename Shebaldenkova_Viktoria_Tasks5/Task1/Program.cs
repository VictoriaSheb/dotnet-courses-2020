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
            //User user = new User();
            User user = new User("Иван","Иванович", "Иванов", new DateTime(3000,1,1));
            user.LookInformationAboutUser();
        }
    }
}
