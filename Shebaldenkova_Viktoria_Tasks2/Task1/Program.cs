using LibArray;
using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Исходный массив элементов:");
            int max;
            int min;
            int[] array = new int[20];
            ArrayTool tool = new ArrayTool();
            array=tool.FillArray(array);
            tool.View(array);

            max =Max(array);
            Console.WriteLine("Max=" + max);

            min = Min(array);
            Console.WriteLine("Min=" + min);

            Console.WriteLine("Сортировка от меньшего к большему значению:");
            Sort(array);
            tool.View(array);
            Console.ReadLine();


           

            int Max(int[] searchInArrayMax) 
            {
                int maxElement = searchInArrayMax[0];
                foreach (int element in searchInArrayMax) 
                {
                    if (maxElement < element)
                        maxElement = element;
                }
                return maxElement;
            }


            int Min(int[] searchInArrayMax)
            {
                int minElement = searchInArrayMax[0];
                foreach (int element in searchInArrayMax)
                {
                    if (minElement > element)
                        minElement = element;
                }
                return minElement;

            }


            int[] Sort(int[] sortArray)
            {
                for (int i = 0; i < sortArray.Length; i++)
                    for (int j = i + 1; j < sortArray.Length; j++)
                        if (sortArray[i] > sortArray[j])
                        {
                            int temp = sortArray[i];
                            sortArray[i] = sortArray[j];
                            sortArray[j] = temp;
                        }
                return sortArray;
            }


           

        }
    }
}
