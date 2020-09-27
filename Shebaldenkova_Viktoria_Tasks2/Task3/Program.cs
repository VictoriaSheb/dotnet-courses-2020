﻿using LibArray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Массив элементов:");
            int[] array = new int[20];
            ArrayTool tool = new ArrayTool();
            array = tool.Сompletion(array);
            tool.View(array);

            Console.WriteLine("Сумма положительных элементов равна: "+SumOfPositiveElements(array));
            Console.ReadLine();

            int SumOfPositiveElements(int[] arrayOne) 
            {
                int sum=default;
                foreach (var element in arrayOne) 
                {
                    if (element >= 0)
                        sum += element;
                }
                return sum;
            }

        }
    }
}