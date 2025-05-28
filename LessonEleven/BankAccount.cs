using System;
using System.Threading;

class BankAccount
{
    public int Id { get; }
    public decimal Balance { get; private set; }
    private readonly object lockObj = new object();

    public BankAccount(int id, decimal initialBalance)
    {
        Id = id;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        lock (lockObj)
        {
            Balance += amount;
            Console.WriteLine($"Account {Id}: Deposited {amount}. New balance: {Balance}");
        }
    }

    public bool Withdraw(decimal amount)
    {
        lock (lockObj)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Account {Id}: Withdrawn {amount}. New balance: {Balance}");
                return true;
            }
            else
            {
                Console.WriteLine($"Account {Id}: Insufficient funds for withdrawal of {amount}.");
                return false;
            }
        }
    }

    public static void Transfer(BankAccount from, BankAccount to, decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Transfer amount must be positive.");
            return;
        }

        object firstLock = from.Id < to.Id ? from.lockObj : to.lockObj;
        object secondLock = from.Id < to.Id ? to.lockObj : from.lockObj;

        lock (firstLock)
        {
            lock (secondLock)
            {
                if (from.Withdraw(amount))
                {
                    to.Deposit(amount);
                    Console.WriteLine($"Successfully transferred {amount} from Account {from.Id} to Account {to.Id}.");
                }
            }
        }
    }
}

class BankAccountTransfer
{
    public static void Execute()
    {
        decimal initialBalance1 = GetValidAmount("Enter initial balance for Account 1: ");
        decimal initialBalance2 = GetValidAmount("Enter initial balance for Account 2: ");

        BankAccount account1 = new BankAccount(1, initialBalance1);
        BankAccount account2 = new BankAccount(2, initialBalance2);

        decimal transferAmount = GetValidAmount("Enter transfer amount from Account 1 to Account 2: ");

        Thread transferThread1 = new Thread(() => BankAccount.Transfer(account1, account2, transferAmount));
        transferThread1.Start();
        transferThread1.Join();

        Console.WriteLine("Final balances:");
        Console.WriteLine($"Account 1: {account1.Balance}");
        Console.WriteLine($"Account 2: {account2.Balance}");

        string response = GetYesOrNoResponse("\nWould you like to transfer funds from Account 2 to Account 1? (yes/no): ");

        if (response == "yes")
        {
            decimal transferBackAmount = GetValidAmount("Enter transfer amount from Account 2 to Account 1: ");
            Thread transferThread2 = new Thread(() => BankAccount.Transfer(account2, account1, transferBackAmount));
            transferThread2.Start();
            transferThread2.Join();

            Console.WriteLine("Final balances after second transfer:");
            Console.WriteLine($"Account 1: {account1.Balance}");
            Console.WriteLine($"Account 2: {account2.Balance}");
        }
        else
        {
            Console.WriteLine("No additional transfers. Program exiting.");
        }
    }

    static decimal GetValidAmount(string prompt)
    {
        decimal amount;
        do
        {
            Console.Write(prompt);
        } while (!decimal.TryParse(Console.ReadLine(), out amount) || amount < 0);

        return amount;
    }

    static string GetYesOrNoResponse(string prompt)
    {
        string response;

        do
        {
            Console.Write(prompt);
            response = Console.ReadLine()?.Trim().ToLower() ?? ""; 

            if (response != "yes" && response != "no")
            {
                Console.WriteLine("Invalid input! Please enter only 'yes' or 'no'.");
            }
        } while (response != "yes" && response != "no");

        return response;
    }
}