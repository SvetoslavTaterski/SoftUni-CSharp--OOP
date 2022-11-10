using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            while (numbers.Count != 10)
            {
                try
                {
                    if (!numbers.Any())
                    {
                        numbers.Add(ReadNumber(1, 100));
                    }
                    else
                    {
                        numbers.Add(ReadNumber(numbers.Max(), 100));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            int number;

            try
            {
                number = int.Parse(input);
            }
            catch(Exception)
            {
                throw new Exception("Invalid Number!");
            }

            if (number <= start || number >= end)
            {
                throw new Exception($"Your number is not in range {start} - {end}!");
            }

            return number;
        }
    }
}
