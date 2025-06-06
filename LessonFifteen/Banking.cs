using System;
using System.Collections.Generic;

public enum AccountCurrency
{
    USD,
    EUR,
    MDL
}

public class Person
{
    public string Name { get; set; }
    public string IdentificationNumber { get; set; } 

    public Person(string name, string identificationNumber)
    {
        Name = name;
        IdentificationNumber = identificationNumber;
    }
}

public class Transaction
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public bool IsDeposit { get; set; }

    public Transaction(decimal amount, bool isDeposit)
    {
        Date = DateTime.Now;
        Amount = amount;
        IsDeposit = isDeposit;
    }
}

public class BankAccount
{
    public string AccountNumber { get; private set; }
    public AccountCurrency Currency { get; private set; }
    public DateTime CreationDate { get; private set; }
    public string Pin { get; private set; }
    public Person Owner { get; private set; }
    private List<Transaction> Transactions { get; set; } = new List<Transaction>();

    public BankAccount(string accountNumber, AccountCurrency currency, string pin, Person owner)
    {
        AccountNumber = accountNumber;
        Currency = currency;
        Pin = pin;
        Owner = owner;
        CreationDate = DateTime.Now;
    }

    public void Deposit(decimal amount)
    {
        Transactions.Add(new Transaction(amount, true));
        Console.WriteLine($"Deposited {amount} {Currency}. Current Balance: {GetBalance()}");
    }

    public void Withdraw(decimal amount)
    {
        if (GetBalance() >= amount)
        {
            Transactions.Add(new Transaction(amount, false));
            Console.WriteLine($"Withdrawn {amount} {Currency}. Current Balance: {GetBalance()}");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public decimal GetBalance()
    {
        decimal balance = 0;
        foreach (var transaction in Transactions)
        {
            balance += transaction.IsDeposit ? transaction.Amount : -transaction.Amount;
        }
        return balance;
    }
}

class BankingOperation
{
    public static void Execute()
    {
        Person person = new Person("Ion Nichifor", "1234567890");
        BankAccount account = new BankAccount("MD12345678", AccountCurrency.MDL, "7890", person);

        account.Deposit(1000);
        account.Withdraw(200);
        account.Deposit(500);

        Console.WriteLine($"Final Balance: {account.GetBalance()} {account.Currency}");
    }
}