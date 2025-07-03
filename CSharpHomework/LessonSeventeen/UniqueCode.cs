using System;

public static class Helper
{
    private static Random random = new Random();

    public static string GenerareCodUnic(string prefix)
    {
        int number = random.Next(1, 999); 
        return $"{prefix}{number}";
    }
}

class UniqueCode
{
    public static void Execute()
    {
        Console.WriteLine(Helper.GenerareCodUnic("USD_"));
        Console.WriteLine(Helper.GenerareCodUnic("EUR_"));
        Console.WriteLine(Helper.GenerareCodUnic("MDL_"));
    }
}