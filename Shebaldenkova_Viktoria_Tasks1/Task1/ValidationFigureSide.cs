using System;

namespace Task1
{
    class ValidationFigureSide
    {
        public int Input(string n)
        {
            int value;
            int lenght;
            string line;
            Console.WriteLine("Введите {0}:", n);
            int top = Console.CursorTop;
            while (int.TryParse(line=Console.ReadLine(), out value) == false)
            {
                Console.SetCursorPosition(0,top);
                lenght = line.Length;
                line = default;
                while ((lenght--)>0) { line += " "; }
                Console.WriteLine(line);
                Console.SetCursorPosition(0,top);
            }
            return value;
        }

        public bool CheckInput(int value)
        {
            return (value <= 0) ? false : true;
        }
    }
}
