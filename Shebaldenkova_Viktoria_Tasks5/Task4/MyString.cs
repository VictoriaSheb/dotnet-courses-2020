using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class MyString
    {
        public char[] Line { set; get; }

        public MyString(string line) 
        {
            this.Line = line.ToCharArray(0, line.Length);
        }
        public MyString(char[] line)
        {
            this.Line = line;
        }


        public static MyString operator +(MyString lineIn, MyString lineFrom)
        {
            string sumLines = string.Concat(lineIn.ToString(), lineFrom.ToString());
            //char[] sumLines = new char[lineIn.line.Length + lineFrom.line.Length];
            //for(int i=0;i<lineIn.line.Length;i++)
            //{
            //    sumLines[i]=lineIn.line[i];
            //}
            //for (int i = 0; i < lineFrom.line.Length; i++)
            //{
            //    sumLines[i+ lineIn.line.Length] = lineFrom.line[i];
            //}

            return new MyString(sumLines);
        }

        public static MyString operator -(MyString line1, MyString line2)
        {
            string line1str = line1.ToString();
            string line2str = line2.ToString();
            int startIndex = line1str.IndexOf(line2str);
            if (startIndex>0)
                line1str=line1str.Remove(startIndex,line2str.Length);
            return new MyString(line1str);


            //if (line1.line.Length - line2.line.Length<0) 
            //{
            //    return line1;
            //}
            //bool comparisonResult = false;
            //int trueOption = default;
            //for (int option = 0; option <= (line1.line.Length - line2.line.Length); option++) 
            //{
            //    for (int i = 0; i < line2.line.Length; i++)
            //    {
            //        if (line1.line[option + i] == line2.line[i])
            //            comparisonResult = true;
            //        else 
            //        {
            //            comparisonResult = false;
            //            break;
            //        }
            //    }
            //    if (comparisonResult == true)
            //    {
            //        trueOption = option;
            //        break;
            //    }
            //}
            //if (comparisonResult == false)
            //    return line1;
            //char[] differenceLines = new char[line1.line.Length-line2.line.Length];
            //int j = 0;
            //for (int i = 0; i < line1.line.Length; i++)
            //    if (i < trueOption || i > (trueOption + line2.line.Length))
            //        differenceLines[j++]=line1.line[i];
            //return new MyString(differenceLines);
        }


        public static bool operator ==(MyString line1, MyString line2) 
        {
            if ((object)line1 == null && (object)line2 == null)
                return true;
            if ((object)line1 == null || (object)line2 == null)
                return false;
            if (string.Compare(line1.ToString(), line2.ToString()) == 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
            //if (line1.line.Length - line2.line.Length != 0)
            //{
            //    return false;
            //}

            //for (int i = 0; i < line1.line.Length; i++) 
            //{
            //    if (line1.line[i] != line2.line[i])
            //        return false;
            //}
            //return true;
        }


        public static bool operator !=(MyString line1, MyString line2)
        {
            return !(line1 == line2);
        }

        public override string ToString()
        {
            string lineStb="";
            foreach (char element in Line)
            {
                lineStb+=element;
            }
            //string result="";
            //foreach (char symbol in line) 
            //{
            //    result += symbol;
            //}
            return lineStb;
        }

    }
}
