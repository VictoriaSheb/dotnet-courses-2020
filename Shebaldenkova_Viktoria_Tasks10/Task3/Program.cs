using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        public delegate void Action();

        static void Main(string[] args)
        {
            Thread thread = new Thread(() => Sort(1));
            thread.Start();
            Sort(2);
            Console.ReadLine();
        }


        public static event Action OnSorted;

        public static void Sort(int number) 
        {
            List<string> lines = new List<string>
            {
                "abcd",
                "wbc",
                "wcccccccc",
                "ddddddddd",
            };
            string swap;
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = i + 1; j < lines.Count; j++)
                {
                    if (!SortTwo(lines[i], lines[j]))
                    {
                        swap = lines[i];
                        lines[i] = lines[j];
                        lines[j] = swap;
                    }
                }
            }
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            
            OnSorted = () => { Console.WriteLine("Массив {0} отсортирован", number); };
            OnSorted?.Invoke();

        }

        public static bool SortTwo(string first, string second)
        {
            if (first.Length == second.Length)
            {
                List<string> sorted = new List<string> { first, second };
                sorted.Sort(StringComparer.CurrentCultureIgnoreCase);
                if (sorted.First() == first)
                    return true;
                else
                    return false;
            }
            if (first.Length > second.Length)
                return false;
            else
                return true;
        }


    }
}

