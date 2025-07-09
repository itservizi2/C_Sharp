namespace LessonTwentyNinexUnitDelegate
{
    using System;
    using System.Collections.Generic;
    using Xunit;
    using Moq;

        public delegate void EventNotification(string message);

        public interface ISubscriber
        {
            void Notify(string message);
        }

        public class EventManager
        {
            private readonly List<EventNotification> subscribers = new();

            public void Subscribe(EventNotification subscriber) => subscribers.Add(subscriber);

            public void Unsubscribe(EventNotification subscriber) => subscribers.Remove(subscriber);

            private void Notify(string message)
            {
                foreach (var subscriber in subscribers)
                    subscriber(message);
            }

            public void CreateEvent(string eventName) => Notify($" New Event Created: {eventName}");

            public void UpdateEvent(string eventName) => Notify($" Event Updated: {eventName}");
        }

        public class EventManagerTests
        {
            [Fact]
            public void CreateEvent_ShouldTriggerNotification_ForAllSubscribers()
            {
                
                var manager = new EventManager();
                var mockSubscriber1 = new Mock<ISubscriber>();
                var mockSubscriber2 = new Mock<ISubscriber>();

                manager.Subscribe(mockSubscriber1.Object.Notify);
                manager.Subscribe(mockSubscriber2.Object.Notify);

                manager.CreateEvent("Unit Test Conference");

                mockSubscriber1.Verify(s => s.Notify(" New Event Created: Unit Test Conference"), Times.Once);
                mockSubscriber2.Verify(s => s.Notify(" New Event Created: Unit Test Conference"), Times.Once);
            }

            [Fact]
            public void UpdateEvent_ShouldNotifyAllSubscribers()
            {
                
                var manager = new EventManager();
                var mockSubscriber = new Mock<ISubscriber>();
                manager.Subscribe(mockSubscriber.Object.Notify);

                manager.UpdateEvent("Design Sprint");

                mockSubscriber.Verify(s => s.Notify(" Event Updated: Design Sprint"), Times.Once);
            }

            [Fact]
            public void Unsubscribe_ShouldPreventNotification()
            {
                
                var manager = new EventManager();
                var mockSubscriber = new Mock<ISubscriber>();

                manager.Subscribe(mockSubscriber.Object.Notify);
                manager.Unsubscribe(mockSubscriber.Object.Notify);

                manager.CreateEvent("Ghost Event");

                mockSubscriber.Verify(s => s.Notify(It.IsAny<string>()), Times.Never);
            }
        }
    
}