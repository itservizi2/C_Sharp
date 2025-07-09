namespace LessonTwentyNine
{
    using System;
    using System.Collections.Generic;

    public delegate void EventNotification(string message);

    public class EventManager
    {
        private List<EventNotification> subscribers = new List<EventNotification>();

        public void Subscribe(EventNotification subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Unsubscribe(EventNotification subscriber)
        {
            subscribers.Remove(subscriber);
        }

        private void Notify(string message)
        {
            foreach (var subscriber in subscribers)
            {
                subscriber(message);
            }
        }

        public void CreateEvent(string eventName)
        {
            Notify($" New Event Created: {eventName}");
        }

        public void UpdateEvent(string eventName)
        {
            Notify($" Event Updated: {eventName}");
        }
    }

}
