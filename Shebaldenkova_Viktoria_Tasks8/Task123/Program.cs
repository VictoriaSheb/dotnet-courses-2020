using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task123
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] num = new int[] { 1, 3, 4 };
            DynamicArray<int> Massiv = new DynamicArray<int>(num);

            //Добавление элемента/массива
            Massiv.Add(6);
            Massiv.AddRange(num);

            //Вставка в начало, середину, конец
            Massiv.Insert(0, 0);
            Massiv.Insert((Massiv.Length - 1) / 2, 55);
            Massiv.Add(99);

            //Удаление элемента
            Massiv.Remove(0);
            Console.WriteLine("Удаление не существующего элемента = {0}", Massiv.Remove(32));

            foreach (var i in Massiv)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Length = {0}", Massiv.Length);
            Console.WriteLine("Capasity = {0}", Massiv.Capacity);


            Console.ReadLine();


        }
    }
}
