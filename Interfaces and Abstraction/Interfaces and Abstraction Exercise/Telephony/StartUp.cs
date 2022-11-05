namespace Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> phoneNumbers = new List<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());
            List<string> URLS = new List<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (string phoneNumber in phoneNumbers)
            {
                if (phoneNumber.All(ch => char.IsDigit(ch)))
                {
                    if (phoneNumber.Length == 7)
                    {
                        stationaryPhone.Call(phoneNumber);
                    }
                    else
                    {
                        smartphone.Call(phoneNumber);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (string URL in URLS)
            {
                if (URL.Any(ch => char.IsDigit(ch)))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    smartphone.Browse(URL);
                }
            }
        }
    }
}
