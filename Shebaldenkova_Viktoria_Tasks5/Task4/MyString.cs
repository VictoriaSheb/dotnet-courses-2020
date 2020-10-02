using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class MyString
    {
        public char[] line { set; get; }

        public MyString(string line) 
        {
            this.line = line.ToCharArray(0, line.Length);
        }
        public MyString(char[] line)
        {
            this.line = line;
        }


        public static MyString operator +(MyString lineIn, MyString lineFrom)
        {
            char[] sumLines = new char[lineIn.line.Length + lineFrom.line.Length];
            for(int i=0;i<lineIn.line.Length;i++)
            {
                sumLines[i]=lineIn.line[i];
            }
            for (int i = 0; i < lineFrom.line.Length; i++)
            {
                sumLines[i+ lineIn.line.Length] = lineFrom.line[i];
            }

            return new MyString(sumLines);
        }

        public static MyString operator -(MyString line1, MyString line2)
        {
            if (line1.line.Length - line2.line.Length<0) 
            {
                return line1;
            }
            bool comparisonResult = false;
            int trueOption = default;
            for (int option = 0; option <= (line1.line.Length - line2.line.Length); option++) 
            {
                for (int i = 0; i < line2.line.Length; i++)
                {
                    if (line1.line[option + i] == line2.line[i])
                        comparisonResult = true;
                    else 
                    {
                        comparisonResult = false;
                        break;
                    }
                }
                if (comparisonResult == true)
                {
                    trueOption = option;
                    break;
                }
            }
            if (comparisonResult == false)
                return line1;
            char[] differenceLines = new char[line1.line.Length-line2.line.Length];
            int j = 0;
            for (int i = 0; i < line1.line.Length; i++)
                if (i < trueOption || i > (trueOption + line2.line.Length))
                    differenceLines[j++]=line1.line[i];
            return new MyString(differenceLines);
        }


        public static bool operator ==(MyString line1, MyString line2) 
        {
            if (line1.line.Length - line2.line.Length != 0)
            {
                return false;
            }

            for (int i = 0; i < line1.line.Length; i++) 
            {
                if (line1.line[i] != line2.line[i])
                    return false;
            }
            return true;
        }


        public static bool operator !=(MyString line1, MyString line2)
        {
            return !(line1 == line2);
        }

        public override string ToString()
        {
            string result="";
            foreach (char symbol in line) 
            {
                result += symbol;
            }
            return result;
        }

    }
}
