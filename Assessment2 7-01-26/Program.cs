class Program
{
    static void Main()
    {
        Ledger<IncomeTransaction> incomeLedger = new Ledger<IncomeTransaction>();

        incomeLedger.AddEntry(new IncomeTransaction
        {
            Id = 1,
            Date = DateTime.Now,
            Amount = 500,
            Description = "Petty Cash Refill",
            Source = "Main Cash"
        });

        Ledger<ExpenseTransaction> expenseLedger = new Ledger<ExpenseTransaction>();

        expenseLedger.AddEntry(new ExpenseTransaction
        {
            Id = 2,
            Date = DateTime.Now,
            Amount = 20,
            Description = "Stationery",
            Category = "Office"
        });

        expenseLedger.AddEntry(new ExpenseTransaction
        {
            Id = 3,
            Date = DateTime.Now,
            Amount = 15,
            Description = "Team Snacks",
            Category = "Food"
        });

        decimal totalIncome = incomeLedger.CalculateTotal();
        decimal totalExpense = expenseLedger.CalculateTotal();
        decimal balance = totalIncome - totalExpense;

        Console.WriteLine("---- INCOME TRANSACTIONS ----");
        List<IncomeTransaction> incomes = incomeLedger.GetAllTransactions();
        for (int i = 0; i < incomes.Count; i++)
        {
            Console.WriteLine(incomes[i].GetSummary());
        }

        Console.WriteLine("\n---- EXPENSE TRANSACTIONS ----");
        List<ExpenseTransaction> expenses = expenseLedger.GetAllTransactions();
        for (int i = 0; i < expenses.Count; i++)
        {
            Console.WriteLine(expenses[i].GetSummary());
        }

        Console.WriteLine("\n---- SUMMARY ----");
        Console.WriteLine("Total Income: " + totalIncome);
        Console.WriteLine("Total Expense: " + totalExpense);
        Console.WriteLine("Net Balance: " + balance);

        Console.ReadLine();
    }
}
