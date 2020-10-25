using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    class Program
    {
        delegate bool SortDelegate(string first, string second);

        static void Main(string[] args)
        {
            List<string> lines = new List<string> 
            {
                "abcd",
                "wbc",
                "wcccccccc",
                "ddddddddd",
            };
            SortDelegate sort;
            string swap;
            sort = SortTwo;
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = i+1; j < lines.Count; j++)
                {
                    if (!sort(lines[i], lines[j]))
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
            Console.ReadLine();

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
















        public static void SortTwo(int first, int second, List<string> list)
        {
            List<string> sorted;
            if (list[first].Length.Equals(list[second].Length))
            {
                (sorted  = list.FindAll(x => (list.IndexOf(x) == first) || (list.IndexOf(x) == second))).Sort(StringComparer.CurrentCultureIgnoreCase);
            }
            else
            {
                if (list[first].Length > list[second].Length)
                {
                    (sorted = list.FindAll(x => (list.IndexOf(x) == first) || (list.IndexOf(x) == second))).Reverse();
                }
                else
                    return;
            }
            list[first] = sorted.First();
            list[second] = sorted.Last();

        }
    }

}
