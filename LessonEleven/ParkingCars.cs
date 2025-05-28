using System;
using System.Threading;

class ParkingLotSimulation
{
    private static Semaphore parkingLot = new Semaphore(3, 3); 

    static void Car(object carNumber)
    {
        Console.WriteLine($"Car {carNumber} is trying to enter...");

        parkingLot.WaitOne(); 
        Console.WriteLine($"Car {carNumber} has entered and parked.");

        Thread.Sleep(new Random().Next(2000, 5000)); 

        Console.WriteLine($"Car {carNumber} is leaving.");
        parkingLot.Release(); 
    }

    public static void Execute()
    {
        Thread[] cars = new Thread[6];

        for (int i = 0; i < 6; i++)
        {
            cars[i] = new Thread(Car);
            cars[i].Start(i + 1);
        }

        foreach (var car in cars)
        {
            car.Join(); 
        }

        Console.WriteLine("Parking lot simulation completed.");
    }
}