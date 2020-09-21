using System;

namespace Task4
{
    class Picture
    {
        public void Input()
        {
            int N;
            if (int.TryParse(Console.ReadLine(), out N) == false)
                Console.WriteLine("Eror");
            else if (N > 0)
                Painting(N);
            else
                Console.WriteLine("Eror");
            Console.ReadLine();
        }

        void Painting(int N)
        {
            string elements;
            for (int numberTriangle = 1; numberTriangle <= N; numberTriangle++)
            {
                int left = N - 1;
                elements = "*";
                for (int rowTriangle = 0; rowTriangle < numberTriangle; rowTriangle++)
                {
                    Console.SetCursorPosition(left, Console.CursorTop);
                    Console.WriteLine(elements);
                    elements += "**";
                    left--;
                }
            }
        }
    }
}
