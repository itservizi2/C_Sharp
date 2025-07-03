using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class AsyncReaderTwo
{
    public static async Task Execute()
    {
        
        string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName
                                  ?? throw new InvalidOperationException("Project directory not found.");

        string directoryPath = Path.Combine(projectDirectory, "MyFiles");

        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine($"Directory not found: {directoryPath}");
            return;
        }

        string[] filePaths = Directory.GetFiles(directoryPath, "*.txt");

        if (filePaths.Length == 0)
        {
            Console.WriteLine("No text files found in the directory.");
            return;
        }

        try
        {
            var tasks = filePaths.Select(ReadLinesAsync).ToArray();
            int[] lineCounts = await Task.WhenAll(tasks);

            foreach (var (file, count) in filePaths.Zip(lineCounts))
            {
                Console.WriteLine($"{Path.GetFileName(file)}: {count} lines");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading files: {ex.Message}");
        }
    }

    static async Task<int> ReadLinesAsync(string filePath)
    {
        try
        {
            using var reader = new StreamReader(filePath);
            int lineCount = 0;
            while (await reader.ReadLineAsync() is not null)
            {
                lineCount++;
            }
            return lineCount;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading {filePath}: {ex.Message}");
            return 0;
        }
    }
}