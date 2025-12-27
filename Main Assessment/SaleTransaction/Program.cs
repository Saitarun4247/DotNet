
using System;

namespace QuickMartTraders
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                ShowMenu();
                Console.Write("Enter your option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        QuickMartTrade.CreateNewTransaction();
                        break;

                    case "2":
                        QuickMartTrade.ViewLastTransaction();
                        break;

                    case "3":
                        QuickMartTrade.CalculateProfitLoss();
                        break;

                    case "4":
                        Console.WriteLine("Thank you. Application closed normally.");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please select between 1 and 4.");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("================== QuickMart Traders ==================");
            Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
            Console.WriteLine("2. View Last Transaction");
            Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
            Console.WriteLine("4. Exit");
        }
    }
}