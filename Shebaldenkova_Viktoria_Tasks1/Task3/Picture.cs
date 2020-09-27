using System;

namespace Task3
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
            int left = numberOfLines-1;
            string elements = "*";
            for (int rowTriangle = 0; rowTriangle < numberOfLines; rowTriangle++) 
            {
                Console.SetCursorPosition(left, Console.CursorTop);
                Console.WriteLine(elements);
                elements += "**";
                left--;
            }
            Console.ReadLine();
            
        }
    }
}
