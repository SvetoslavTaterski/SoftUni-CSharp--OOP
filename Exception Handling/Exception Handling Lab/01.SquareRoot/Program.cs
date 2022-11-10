using System;

namespace _01.SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double number = double.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new Exception("Invalid number.");
                }

                Console.WriteLine(Math.Sqrt(number));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
