using System;

namespace LibArray
{
    public class ArrayTool
    {
        public int[] FillArray(int[] arrayСompletion)
        {
            Random rand = new Random();
            for (int i = 0; i < arrayСompletion.Length; i++)
                arrayСompletion[i] = rand.Next(-60, 60);
            return arrayСompletion;
        }

        public int[,] FillArray(int[,] arrayСompletion, int first, int second)
        {
            Random rand = new Random();
            for (int x = 0; x < first; x++)
                for (int y = 0; y < second; y++)
                    arrayСompletion[x,y] = rand.Next(-3, 4);
            return arrayСompletion;
        }

        public int[,,] FillArray(int[,,] array, int first, int second, int third)
        {
            Random rand = new Random();
            for (int x = 0; x < first; x++)
                for (int y = 0; y < second; y++)
                    for (int z = 0; z < third; z++)
                        array[x, y, z] = rand.Next(-60, 60);
            return array;
        }

        public void View(int[] viewArray)
        {
            foreach (int element in viewArray)
            {
                Console.Write(element + " ");
            }
            Console.CursorTop++;
            Console.CursorLeft = 0;
        }

        public void View(int[,] arrayView, int first, int second) 
        {
            int leftNow;
            int leftMax = 0;
            int top = Console.CursorTop;
            for (int x = 0; x < first; x++)
            {
                Console.CursorTop = top;
                Console.CursorLeft = leftMax;
                leftNow = leftMax;
                for (int y = 0; y < second; y++)
                {
                    if (arrayView[x, y] >= 0)
                        Console.Write(" ");
                    Console.Write(arrayView[x, y] + "  ");
                    if (leftMax < Console.CursorLeft)
                        leftMax = Console.CursorLeft;
                    Console.CursorLeft = leftNow;
                    Console.CursorTop++;
                }
                Console.WriteLine();
            }

        }

        public void View(int[,,] arrayView, int first, int second, int third)
        {
            int leftNow;
            int leftMax = 0;
            int top = Console.CursorTop;
            for (int x = 0; x < first; x++)
            {
                for (int y = 0; y < second; y++)
                {
                    Console.CursorTop = top;
                    Console.CursorLeft = leftMax;
                    leftNow = leftMax;
                    for (int z = 0; z < third; z++)
                    {
                        if (arrayView[x, z, y] >= 0)
                            Console.Write(" ");
                        Console.Write(arrayView[x, z, y] + "  ");
                        if (leftMax < Console.CursorLeft)
                            leftMax = Console.CursorLeft;
                        Console.CursorLeft = leftNow;
                        Console.CursorTop++;
                    }
                    Console.WriteLine();
                }
                top = Console.CursorTop += 2;
                leftMax = 0;
            }
        }




    }
}
