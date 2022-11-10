using System;
using System.Linq;
using System.Text;

namespace _05.PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int exceptionCount = 0;

            while (exceptionCount != 3)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                string action = command[0];

                try
                {
                    if (action == "Show")
                    {
                        int index = int.Parse(command[1]);
                        Console.WriteLine(numbers[index]);
                    }
                    else if (action == "Print")
                    {
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);
                        StringBuilder sb = new StringBuilder();

                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            sb.Append($"{numbers[i]}, ");
                        }

                        Console.WriteLine(sb.ToString().TrimEnd(',',' '));
                    }
                    else if (action == "Replace")
                    {
                        int index = int.Parse(command[1]);
                        int element = int.Parse(command[2]);

                        numbers[index] = element;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionCount++;
                }
                catch(FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionCount++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
