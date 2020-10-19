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
            List<int> people1 = RamdomList(7);
            RemoveEachSecondItem(ref people1);
            LinkedList<int> people2 = RamdomLinkedList(7);
            RemoveEachSecondItem(ref people2);
            Console.WriteLine("List<T> вычеркивание: "+ people1.First());
            Console.WriteLine("LinkedList<T> вычеркивание: " + people2.First());
            Console.ReadLine();

        }

        public static List<int> RamdomList(int n)
        {
            List<int> people = new List<int>(n);
            for (int i=0;i<n;i++) 
            {
                people.Add(i+1);
            }
            return people;
        }

        public static LinkedList<int> RamdomLinkedList(int n)
        {
            LinkedList<int> people = new LinkedList<int>();
            for (int i = 0; i < n; i++)
            {
                people.AddLast(i + 1);
            }
            return people;
        }

        public static void RemoveEachSecondItem(ref List<int> list) 
        {
            for (int i = 1; i < list.Count; i++)
            {
                list.RemoveAt(i);
                if (list.Count == 1)
                    break;
                if ((i + 1) == list.Count)
                    i = -1;
                if ((i + 1) > list.Count)
                    i = 0;
            }
            
        }
        public static void RemoveEachSecondItem(ref LinkedList<int> list)
        {
            int element = list.First.Next.Value;
            int elementNext = list.First.Next.Next.Value;
            while (list.Count != 1)
            {
                list.Remove(element);
                if (list.Count == 1)
                    break;
                element = (list.Find(elementNext).Next ?? list.First).Value;
                elementNext = (list.Find(element).Next ?? list.First).Value;
            }

        }
    }
}

