using LibArray;
using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int size1 = 3;
            int size2 = 3;
            int size3 = 3;
            int[,,] array = new int[size1, size2, size3];

            ArrayTool tool = new ArrayTool();
            array=tool.Сompletion(array, size1, size2, size3);

            Console.WriteLine("Исходный 3-ехмерный массив:");
            Console.WriteLine();
            tool.View(array, size1, size2, size3);

            ReplacementForZero(array, size1, size2, size3);

            Console.WriteLine("Замена положительных чисел на 0:");
            Console.WriteLine();
            tool.View(array, size1, size2, size3);

            Console.ReadLine();


            

            int[,,] ReplacementForZero(int[,,] arrayReplace, int first, int second, int third)
            {
                for (int x = 0; x < first; x++)
                    for (int y = 0; y < second; y++)
                        for (int z = 0; z < third; z++)
                            if (arrayReplace[x, y, z] > 0)
                                arrayReplace[x, y, z] = 0;
                return arrayReplace;
            }
        }
    }
}
