using System;

namespace Task2
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
            string elements="*";
            while ((numberOfLines--) != 0) 
            {
                Console.WriteLine(elements);
                elements += "*";
            }
            Console.ReadLine();
        }
    }
}
