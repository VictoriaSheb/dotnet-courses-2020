using System;

namespace Task2
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
            string elements="*";
            while ((N--) != 0) 
            {
                Console.WriteLine(elements);
                elements += "*";
            }
        }
    }
}
