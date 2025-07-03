namespace LessonTwentyFive
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            IWorkable humanWorker = new HumanWorker();
            IEatable humanEater = (IEatable)humanWorker;

            IWorkable robotWorker = new RobotWorker();

            var humanWorkManager = new WorkManager(humanWorker);
            var humanEatManager = new EatManager(humanEater);

            var robotWorkManager = new WorkManager(robotWorker);
            
            Console.WriteLine("Managing human:");
            humanWorkManager.Manage();
            humanEatManager.Manage();

            Console.WriteLine("\nManaging robot:");
            robotWorkManager.Manage();

        }
    }
}
