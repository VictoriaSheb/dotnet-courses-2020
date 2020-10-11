using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            GeometricProgression progression = new GeometricProgression(1,5);
            progression.PrintSeries(12);
            progression.Reset();
            progression.PrintSeries(10000);
            Console.ReadLine();
        }

        
    }
    
    public interface ISeries
    {
        double GetCurrent();
        bool MoveNext();
        void Reset();
    }


    class GeometricProgression : ISeries
    {
        double Denominator;
        double Start;
        int Index;

        public GeometricProgression(double startNumber, double denominator) 
        {
            Start = startNumber;
            Index = 0;
            Denominator = denominator;
        }

        public double GetCurrent()
        {
            return Start * Math.Pow(Denominator,Index);
        }

        public bool MoveNext()
        {
            Index++;
            if (!double.IsInfinity(GetCurrent()))
            {
                return true;
            }
            else
            {
                Index--;
                return false;
            }
        }

        public void Reset()
        {
            Index = 0;
        }

        public void PrintSeries(int countSeries) 
        {
            int TryIndex = Index;
            Console.WriteLine("Геометрическая прогрессия: ");
            for (int i = TryIndex-1; i < (TryIndex+countSeries); i++) 
            {
                Index = i;
                if (MoveNext())
                    Console.WriteLine(GetCurrent());
                else
                {
                    Console.WriteLine("Элемент № {0} превышает допустимое значение переменной double",i);
                    break;
                }
            }
            Index = TryIndex;
        }
    }
}
