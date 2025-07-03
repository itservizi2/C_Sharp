using System;
using System.Threading;

class DatabaseAccessSimulation
{
    private static SemaphoreSlim databaseAccess = new SemaphoreSlim(3, 3); 

    static void AccessDatabase(object? connectionId)
    {
        if (connectionId is null)
        {
            Console.WriteLine("Invalid connection ID.");
            return;
        }

        Console.WriteLine($"Connection {connectionId} is trying to access the database...");

        databaseAccess.Wait(); 
        Console.WriteLine($"Connection {connectionId} has connected to the database.");

        Thread.Sleep(new Random().Next(2000, 5000)); 

        Console.WriteLine($"Connection {connectionId} is closing.");
        databaseAccess.Release(); 
    }

    public static void Execute()
    {
        Thread[] connections = new Thread[6];

        for (int i = 0; i < 6; i++)
        {
            connections[i] = new Thread(AccessDatabase);
            connections[i].Start(i + 1);
        }

        foreach (var connection in connections)
        {
            connection.Join(); 
        }

        Console.WriteLine("Database access simulation completed.");
    }
}