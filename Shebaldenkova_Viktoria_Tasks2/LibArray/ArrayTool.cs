using System;

namespace LibArray
{
    public class ArrayTool
    {
        public int[] Сompletion(int[] arrayСompletion)
        {
            Random rand = new Random();
            for (int i = 0; i < arrayСompletion.Length; i++)
                arrayСompletion[i] = rand.Next(-60, 60);
            return arrayСompletion;
        }

        public int[,,] Сompletion(int[,,] arrayСompletion, Random rand, int first, int second, int third)
        {
            for (int x = 0; x < first; x++)
                for (int y = 0; y < second; y++)
                    for (int z = 0; z < third; z++)
                        arrayСompletion[x, y, z] = rand.Next(-60, 60);
            return arrayСompletion;
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
