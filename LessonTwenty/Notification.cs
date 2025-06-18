using System;
using System.Collections.Generic;

abstract class Notification
{
    public string Recipient { get; set; }
    public string Message { get; set; }

    public Notification(string recipient, string message)
    {
        Recipient = recipient;
        Message = message;
    }

    public abstract void Send();
    public abstract string Preview();

    public void SendUrgent()
    {
        Console.WriteLine($"Urgent notification sent to {Recipient}: {Message}");
    }

    public void SendUrgent(int retryCount)
    {
        Console.WriteLine($"Urgent notification sent to {Recipient} with {retryCount} retries: {Message}");
    }

    public void SendUrgent(bool notifyAdmin)
    {
        Console.WriteLine($"Urgent notification sent to {Recipient}: {Message}. Admin notified: {notifyAdmin}");
    }
}

class EmailNotification : Notification
{
    public EmailNotification(string recipient, string message) : base(recipient, message) { }

    public override void Send()
    {
        Console.WriteLine($"Sending Email to {Recipient}: {Message}");
    }

    public override string Preview()
    {
        return $"[Email Preview] To: {Recipient}, Message: {Message}";
    }
}

class SmsNotification : Notification
{
    public SmsNotification(string recipient, string message) : base(recipient, message) { }

    public override void Send()
    {
        Console.WriteLine($"Sending SMS to {Recipient}: {Message}");
    }

    public override string Preview()
    {
        return $"[SMS Preview] To: {Recipient}, Message: {Message}";
    }
}

class PushNotification : Notification
{
    public PushNotification(string recipient, string message) : base(recipient, message) { }

    public override void Send()
    {
        Console.WriteLine($"Sending Push Notification to {Recipient}: {Message}");
    }

    public override string Preview()
    {
        return $"[Push Notification Preview] To: {Recipient}, Message: {Message}";
    }
}

class InAppNotification : Notification
{
    public InAppNotification(string recipient, string message) : base(recipient, message) { }

    public override void Send()
    {
        Console.WriteLine($"Saving In-App Notification for {Recipient}: {Message}");
    }

    public override string Preview()
    {
        return $"[In-App Notification Preview] To: {Recipient}, Message: {Message}";
    }
}

class NotificationService
{
    public void SendAll(List<Notification> notifications)
    {
        foreach (var notification in notifications)
        {
            notification.Send();
        }
    }

    public void GenerateReport(List<Notification> notifications)
    {
        Console.WriteLine("Notification Report:");
        foreach (var notification in notifications)
        {
            Console.WriteLine(notification.Preview());
        }
    }
}

class NotificationManager
{
    public static void Execute()
    {
        List<Notification> notifications = new List<Notification>
        {
            new EmailNotification("PetreMarinescu@gmail.com", "Welcome to our service!"),
            new SmsNotification("+37369555632", "Your verification code is 1234"),
            new PushNotification("PetreMarinescu", "You have a new message!"),
            new InAppNotification("PetreMarinescu", "Your order has been processed.")
        };

        NotificationService notificationService = new NotificationService();
        notificationService.SendAll(notifications);
        notificationService.GenerateReport(notifications);

    }
}