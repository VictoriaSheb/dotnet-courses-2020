using System;

namespace Task4
{
    class Picture
    {
        int numberOfLines { set; get; }
        public bool Input()
        {
            int readNumberOfLines;
            if (int.TryParse(Console.ReadLine(), out readNumberOfLines) == false)
                Console.WriteLine("Ошибка: подразумевается целое число");
            else if (readNumberOfLines > 0)
            {
                numberOfLines = readNumberOfLines;
                return true;
            }
            else
                Console.WriteLine("Ошибка: значение не может быть меньше нуля");
            return false;
        }

        public void Painting()
        {
            string elements;
            for (int numberTriangle = 1; numberTriangle <= numberOfLines; numberTriangle++)
            {
                int left = numberOfLines - 1;
                elements = "*";
                for (int rowTriangle = 0; rowTriangle < numberTriangle; rowTriangle++)
                {
                    Console.SetCursorPosition(left, Console.CursorTop);
                    Console.WriteLine(elements);
                    elements += "**";
                    left--;
                }
            }
            Console.ReadLine();
        }
    }
}
