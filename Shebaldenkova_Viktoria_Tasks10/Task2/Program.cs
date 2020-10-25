using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>()
            {
                new Person() { Name = "Джон" },
                new Person() { Name = "Билл" },
                new Person() { Name = "Хьюго"}
            };

            persons[0].GoToOffice(persons);
            persons[1].GoToOffice(persons);
            persons[2].GoToOffice(persons);



            persons[0].GoHome(persons);
            persons[1].GoHome(persons);



            persons[1].GoToOffice(persons);
            persons[0].GoToOffice(persons);



            persons[2].GoHome(persons);

            Console.ReadLine();
        }
    }
}
