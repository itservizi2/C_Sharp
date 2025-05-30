using System;
using System.Diagnostics;
using System.Threading.Tasks;

class OrderProcessor
{
    private static readonly Random random = new Random();

    public async Task ProcessOrderAsync(int orderId)
    {
        int delay = random.Next(2000, 5001); 
        Stopwatch stopwatch = Stopwatch.StartNew();

        await Task.Delay(delay); 

        stopwatch.Stop();
        Console.WriteLine($"Order {orderId} processed in {stopwatch.ElapsedMilliseconds} ms.");
    }
}

class ProgramProcessingOrders
{
    public static async Task Execute()
    {
        OrderProcessor processor = new OrderProcessor();
        Task[] tasks = new Task[5];

        for (int i = 0; i < 5; i++)
        {
            tasks[i] = processor.ProcessOrderAsync(i + 1);
        }

        await Task.WhenAll(tasks); 
    }
}