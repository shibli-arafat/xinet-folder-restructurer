using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Problems
    {
        public static bool IsPrime(int number)
        {
            number = Math.Abs(number);
            bool isPrime = true;
            for (int i = 2; i < number; i++)
            {
                if(number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }

        public static int FindNthFactor(int number, int factorNumber)
        {
            List<int> factors = new List<int>();
            Console.WriteLine("Factors of number {0}:", number);
            for (int i = 1; i <= number; i++)
            {
                if(number % i == 0)
                {
                    Console.WriteLine(i);
                    factors.Add(i);
                }
            }
            return (factors.Count < factorNumber)? 0 : factors[factorNumber - 1];
        }
    }
}
