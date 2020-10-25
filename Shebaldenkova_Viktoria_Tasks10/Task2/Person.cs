using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{

    public delegate void PersonCameEventHandler(Person person, DateTime time);
    public delegate void PersonLeaveEventHandler(Person person);
    public class Person
    {

        public string Name { get; set; }

        public void SayHello(Person person, DateTime time)
        {
            if (time.Hour < 12)
            {
                Console.WriteLine($"Доброе утро, {person.Name}! - сказал {this.Name}");
            }
            else
            {
                if (time.Hour >= 17)
                {
                    Console.WriteLine($"Добрый вечер, {person.Name},- сказал {this.Name}");
                }
                else
                {
                    Console.WriteLine($"Добрый день, {person.Name},- сказал {this.Name}");
                }
            }

        }

        public void SayBye(Person person)
        { Console.WriteLine($"До свидания, {person.Name}! - сказал {this.Name}"); }






        //Пришел на работу
        public PersonCameEventHandler OnCame1;
        public event PersonCameEventHandler OnCame;
        public void GoToOffice(List<Person> persons)
        {
            Console.WriteLine(" ");
            Console.WriteLine($"[На работу пришел {Name}]");
            foreach (var person in persons)
                //каждый пришедший сотрудник подписывается на то, что его поприветствуют
            { person.OnCame += this.SayHello;

                person.OnCame1 += this.SayHello;
            }
            this.OnCame -= this.SayHello;
            this.OnCame1 -= this.SayHello;

            foreach (var person in persons)
            { person.OnLeave += this.SayBye; }
            this.OnLeave -= this.SayBye;
            OnCame?.Invoke(this, DateTime.Now);
            OnCame1?.Invoke(this, DateTime.Now);
        }

        //Ушел 
        public event PersonLeaveEventHandler OnLeave;
        public void GoHome(List<Person> persons)
        {
            Console.WriteLine(" ");
            Console.WriteLine($"[{Name} ушел домой]");
            foreach (var person in persons)
            { person.OnCame -= this.SayHello; }

            foreach (var person in persons)
            { person.OnLeave -= this.SayBye; }
            OnLeave?.Invoke(this);
        }
    }


}
