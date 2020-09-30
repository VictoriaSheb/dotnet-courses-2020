using LibArray;
using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int size1 = 3;
            int size2 = 3;
            int[,] array = new int[size1, size2];
            ArrayTool tool = new ArrayTool();
            array = tool.FillArray(array, size1, size2);

            Console.WriteLine("2-ухмерный массив:");
            Console.WriteLine();
            tool.View(array, size1, size2);
            Console.WriteLine("Сумма элементов, стоящих на четных позициях: "+ SumOfEvenPositions(array, size1, size2));
            Console.ReadLine();

            int SumOfEvenPositions(int[,] arrayTwo, int first, int second) 
            {
                int sum=default;
                for (int i = 0; i < first; i++)
                    for (int j = 0; j < second; j++)
                        if (((i + j) % 2) == 0)
                            sum += arrayTwo[i,j];
                return sum;
            }
        }
    }
}
