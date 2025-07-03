using System;

class DisplayOnlyEven
{
    public static void Execute()
    {
        Console.WriteLine("Even numbers from 1 to 100:");

        for (int i = 2; i <= 100; i += 2) 
        {
            Console.Write(i + " ");
        }

        Console.WriteLine(); 
    }
}
