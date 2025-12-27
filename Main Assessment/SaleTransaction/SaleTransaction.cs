using System;

namespace QuickMartTraders
{

    public class SaleTransaction
    {
        public string InvoiceNo;
        public string CustomerName;
        public string ItemName;
        public int Quantity;
        public decimal PurchaseAmount;
        public decimal SellingAmount;
        public string ProfitOrLossStatus;
        public decimal ProfitOrLossAmount;
        public decimal ProfitMarginPercent;
    }

    // BUSINESS LOGIC CLASS
    public class QuickMartTrade
    {
        public static SaleTransaction LastTransaction = null;
        public static bool HasLastTransaction = false;

        public static void CreateNewTransaction()
        {
            SaleTransaction transaction = new SaleTransaction();

            Console.Write("Enter Invoice No: ");
            transaction.InvoiceNo = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(transaction.InvoiceNo))
            {
                Console.WriteLine("Invoice No cannot be empty.");
                return;
            }

            Console.Write("Enter Customer Name: ");
            transaction.CustomerName = Console.ReadLine();

            Console.Write("Enter Item Name: ");
            transaction.ItemName = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out transaction.Quantity) || transaction.Quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than 0.");
                return;
            }

            Console.Write("Enter Purchase Amount (total): ");
            if (!decimal.TryParse(Console.ReadLine(), out transaction.PurchaseAmount) || transaction.PurchaseAmount <= 0)
            {
                Console.WriteLine("Purchase Amount must be greater than 0.");
                return;
            }

            Console.Write("Enter Selling Amount (total): ");
            if (!decimal.TryParse(Console.ReadLine(), out transaction.SellingAmount) || transaction.SellingAmount < 0)
            {
                Console.WriteLine("Selling Amount cannot be negative.");
                return;
            }

            ComputeProfitLoss(transaction);

            LastTransaction = transaction;
            HasLastTransaction = true;

            Console.WriteLine("\nTransaction saved successfully.");
            PrintResult(transaction);
        }

        public static void ViewLastTransaction()
        {
            if (!HasLastTransaction)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            Console.WriteLine("\n-------------- Last Transaction --------------");
            Console.WriteLine("InvoiceNo: " + LastTransaction.InvoiceNo);
            Console.WriteLine("Customer: " + LastTransaction.CustomerName);
            Console.WriteLine("Item: " + LastTransaction.ItemName);
            Console.WriteLine("Quantity: " + LastTransaction.Quantity);
            Console.WriteLine("Purchase Amount: " + LastTransaction.PurchaseAmount.ToString("F2"));
            Console.WriteLine("Selling Amount: " + LastTransaction.SellingAmount.ToString("F2"));
            Console.WriteLine("Status: " + LastTransaction.ProfitOrLossStatus);
            Console.WriteLine("Profit/Loss Amount: " + LastTransaction.ProfitOrLossAmount.ToString("F2"));
            Console.WriteLine("Profit Margin (%): " + LastTransaction.ProfitMarginPercent.ToString("F2"));
            Console.WriteLine("--------------------------------------------");
        }

        public static void CalculateProfitLoss()
        {
            if (!HasLastTransaction)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            ComputeProfitLoss(LastTransaction);
            Console.WriteLine("\nRecomputed Profit/Loss:");
            PrintResult(LastTransaction);
        }

        private static void ComputeProfitLoss(SaleTransaction transaction)
        {
            if (transaction.SellingAmount > transaction.PurchaseAmount)
            {
                transaction.ProfitOrLossStatus = "PROFIT";
                transaction.ProfitOrLossAmount = transaction.SellingAmount - transaction.PurchaseAmount;
            }
            else if (transaction.SellingAmount < transaction.PurchaseAmount)
            {
                transaction.ProfitOrLossStatus = "LOSS";
                transaction.ProfitOrLossAmount = transaction.PurchaseAmount - transaction.SellingAmount;
            }
            else
            {
                transaction.ProfitOrLossStatus = "BREAK-EVEN";
                transaction.ProfitOrLossAmount = 0;
            }

            transaction.ProfitMarginPercent =
                (transaction.PurchaseAmount != 0)
                ? (transaction.ProfitOrLossAmount / transaction.PurchaseAmount) * 100
                : 0;
        }

        private static void PrintResult(SaleTransaction t)
        {
            Console.WriteLine("Status: " + t.ProfitOrLossStatus);
            Console.WriteLine("Profit/Loss Amount: " + t.ProfitOrLossAmount.ToString("F2"));
            Console.WriteLine("Profit Margin (%): " + t.ProfitMarginPercent.ToString("F2"));
            Console.WriteLine("------------------------------------------------------");
        }
    }
}