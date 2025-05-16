using System;

class ChessBoard
{
    public static void Execute()
    {
        int size = 8; 
        int[,] board = new int[size, size];

        int whiteValue = GetValidInput("Enter the value for white cells (suggested: 1): ");
        int blackValue = GetValidInput("Enter the value for black cells (suggested: 0): ");

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                board[i, j] = (i + j) % 2 == 0 ? whiteValue : blackValue;
            }
        }

        Console.WriteLine("\nChessboard representation:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private static int GetValidInput(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out value) && (value == 0 || value == 1))
            {
                return value;
            }
            Console.WriteLine("Invalid input! Only 0 and 1 are acceptable values. Please try again.");
        }
    }
}