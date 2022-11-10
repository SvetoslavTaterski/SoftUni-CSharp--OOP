using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.MoneyTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] accountInformations = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Dictionary<int, double> accounts = new Dictionary<int, double>();

            foreach (string account in accountInformations)
            {
                string[] accountInfo = account.Split("-").ToArray();
                int accountNumber = int.Parse(accountInfo[0]);
                double accountBalance = double.Parse(accountInfo[1]);

                accounts.Add(accountNumber, accountBalance);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split().ToArray();
                string action = tokens[0];
                int accountNumber = int.Parse(tokens[1]);
                double sum = double.Parse(tokens[2]);
                try
                {
                    if (action == "Deposit")
                    {
                        if (accounts.Any(a => a.Key == accountNumber))
                        {
                            accounts[accountNumber] += sum;
                            Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
                        }
                        else
                        {
                            throw new ArgumentException("Invalid account!");
                        }
                    }
                    else if (action == "Withdraw")
                    {
                        if (accounts.Any(a => a.Key == accountNumber))
                        {
                            if (accounts[accountNumber] < sum)
                            {
                                throw new ArgumentException("Insufficient balance!");
                            }
                            else
                            {
                                accounts[accountNumber] -= sum;
                                Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Invalid account!");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

            }
        }
    }
}
