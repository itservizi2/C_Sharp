using System;
using System.Collections.Generic;

class DuplicatesRemove
{
    public static void Execute()
    {
        int size;

        do
        {
            Console.Write("Enter the size of the array (positive integer): ");
        } while (!int.TryParse(Console.ReadLine(), out size) || size <= 0);

        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            Console.Write($"Enter element {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.Write($"Invalid input! Please enter a valid integer for element {i + 1}: ");
            }
        }

        HashSet<int> uniqueElements = new HashSet<int>(array);

        Console.WriteLine("\nArray after removing duplicates:");
        Console.WriteLine(string.Join(", ", uniqueElements));
    }
}
