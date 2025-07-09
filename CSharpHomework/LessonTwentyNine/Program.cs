namespace LessonTwentyNine
{
    internal class Program
    {
        static void Main()
        {
            EventManager manager = new EventManager();

            void ConsoleSubscriber(string message) => Console.WriteLine($"Console Notification: {message}");
            void EmailSubscriber(string message) => Console.WriteLine($"Email Sent: {message}");
            void SmsSubscriber(string message) => Console.WriteLine($"SMS Sent: {message}");

            manager.Subscribe(ConsoleSubscriber);
            manager.Subscribe(EmailSubscriber);
            manager.Subscribe(SmsSubscriber);

            manager.CreateEvent("Tech Conference 2025");
            manager.UpdateEvent("Tech Conference 2025");

            manager.Unsubscribe(EmailSubscriber);
            manager.CreateEvent("Design Meetup 2025");
        }
    }
}
