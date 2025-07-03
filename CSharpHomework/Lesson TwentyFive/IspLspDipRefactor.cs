using System;

    public interface IWorkable
    {
        void Work();
    }

    public interface IEatable
    {
        void Eat();
    }

    public class HumanWorker : IWorkable, IEatable
    {
        public void Work()
        {
            Console.WriteLine("Human working...");
        }

        public void Eat()
        {
            Console.WriteLine("Human eating...");
        }
    }

    public class RobotWorker : IWorkable
    {
        public void Work()
        {
            Console.WriteLine("Robot working...");
        }
    }

    public class WorkManager
    {
        private readonly IWorkable _worker;

        public WorkManager(IWorkable worker)
        {
            _worker = worker;
        }

        public void Manage()
        {
            _worker.Work();
        }
    }

    public class EatManager
    {
        private readonly IEatable _eater;

        public EatManager(IEatable eater)
        {
            _eater = eater;
        }

        public void Manage()
        {
            _eater.Eat();
        }
    }
