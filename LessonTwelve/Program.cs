using System;

using System;
using System.Threading.Tasks;

namespace LessonTwelve
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Lesson Twelve Homework");

            await AsyncReader.Execute();
            await ProgramProcessingOrders.Execute();
            
        }
    }
}