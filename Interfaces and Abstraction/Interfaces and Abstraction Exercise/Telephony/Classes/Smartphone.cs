namespace Telephony
{
    using System;

    public class Smartphone : ISmartPhone
    {
        public void Browse(string site)
        {
            Console.WriteLine($"Browsing: {site}!");
        }

        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
