using System;
using System.Collections.Generic;

public interface IReportable
{
    string GetSummary();
}

public abstract class Transaction : IReportable
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }

    public abstract string GetSummary();
}

public class IncomeTransaction : Transaction
{
    public string Source { get; set; }

    public override string GetSummary()
    {
        return "Income | Amount: " + Amount + " | Source: " + Source;
    }
}

public class ExpenseTransaction : Transaction
{
    public string Category { get; set; }

    public override string GetSummary()
    {
        return "Expense | Amount: " + Amount + " | Category: " + Category;
    }
}

public class Ledger<T> where T : Transaction
{
    private List<T> transactions = new List<T>();

    public void AddEntry(T entry)
    {
        transactions.Add(entry);
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;

        for (int i = 0; i < transactions.Count; i++)
        {
            total += transactions[i].Amount;
        }

        return total;
    }

    public List<T> GetAllTransactions()
    {
        return transactions;
    }
}