using System;

namespace Task3
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
            int left = N-1;
            string elements = "*";
            for (int rowTriangle = 0; rowTriangle < N; rowTriangle++) 
            {
                Console.SetCursorPosition(left, Console.CursorTop);
                Console.WriteLine(elements);
                elements += "**";
                left--;
            }

            
        }
    }
}
