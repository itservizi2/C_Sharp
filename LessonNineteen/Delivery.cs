using System;
using System.Collections.Generic;

interface IDelivery
{
    void DeliverPackage();
    void ShowDeliveryDetails();
}

abstract class DeliveryBase : IDelivery
{
    private Guid deliveryId;
    private string recipient;
    private string address;
    private double weight;

    public Guid DeliveryId => deliveryId;
    public string Recipient => recipient;
    public string Address => address;
    public double Weight => weight;

    protected DeliveryBase(string recipient, string address, double weight)
    {
        deliveryId = Guid.NewGuid();
        this.recipient = recipient;
        this.address = address;
        this.weight = weight;
    }

    public abstract void DeliverPackage();
    public abstract void ShowDeliveryDetails();
}

class DroneDelivery : DeliveryBase
{
    public DroneDelivery(string recipient, string address, double weight)
        : base(recipient, address, weight) { }

    public override void DeliverPackage()
    {
        Console.WriteLine($"Drone dispatched to {Address}. Estimated time: 15 minutes.");
    }

    public override void ShowDeliveryDetails()
    {
        Console.WriteLine($"[Drone Delivery] ID: {DeliveryId}\nRecipient: {Recipient}\nAddress: {Address}\nWeight: {Weight} kg\n");
    }
}

class CourierDelivery : DeliveryBase
{
    public CourierDelivery(string recipient, string address, double weight)
        : base(recipient, address, weight) { }

    public override void DeliverPackage()
    {
        Console.WriteLine($"Courier en route to {Address}. Please expect delivery by end of day.");
    }

    public override void ShowDeliveryDetails()
    {
        Console.WriteLine($"[Courier Delivery] ID: {DeliveryId}\nRecipient: {Recipient}\nAddress: {Address}\nWeight: {Weight} kg\n");
    }
}

class DeliverySystem 
{
    public static void Execute()
    {
        List<IDelivery> deliveries = new List<IDelivery>
        {
            new DroneDelivery("Ion Popescu", "Str. Libertatii 45", 2.5),
            new CourierDelivery("Maria Ionescu", "Bd. Unirii 12", 5.0)
        };

        foreach (var delivery in deliveries)
        {
            delivery.ShowDeliveryDetails();
            delivery.DeliverPackage();
            Console.WriteLine("--------\n");
        }
    }
}