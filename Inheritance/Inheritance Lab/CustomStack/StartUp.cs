using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            stack.AddRange(new string[4] { "1", "2", "3", "4" });
            stack.AddRange(new string[4] { "5", "6", "7", "8" });

            while (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
