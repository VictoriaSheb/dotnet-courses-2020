using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            RoundService roundService = new RoundService();

            roundService.AddNewRound(0, 0, 5);
            Round round = roundService.round;
            Console.WriteLine("Длина окружности: "+round.LengthRound);
            
            roundService.AddNewRound(0, 0, -1);
            Round round1 = roundService.round;
            Console.WriteLine("Длина окружности: " + round1.LengthRound);
            
            Console.WriteLine("Длина окружности: " + round.LengthRound);
            
            Console.ReadLine();

        }
    }
}
