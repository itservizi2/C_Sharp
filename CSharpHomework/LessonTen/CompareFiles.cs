using System;
using System.IO;

class CompareFiles
{
    public static void Execute()
    {
        // Important! In Windows in case a relative path is used instead of an absolute one, the Path should be set Relative to
        // Bin folder, so we have to navigate 3 times UP to the project root from bin\Debug\net8.0\
        string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        string directoryPath = Path.Combine(projectDirectory, "CompareFiles");
        string filePath1 = Path.Combine(directoryPath, "file1.txt");
        string filePath2 = Path.Combine(directoryPath, "file2.txt");

        try
        {
            
            Console.WriteLine($"Resolved Project Directory: {projectDirectory}");
            Console.WriteLine($"Resolved Folder Path: {directoryPath}");

            Directory.CreateDirectory(directoryPath);
            Console.WriteLine("Folder created successfully.");

            using (StreamWriter writer1 = new StreamWriter(filePath1, false))
            {
                writer1.Write(""); 
            }
            using (StreamWriter writer2 = new StreamWriter(filePath2, false))
            {
                writer2.Write(""); 
            }

            Console.WriteLine("Files created successfully.");

            Console.WriteLine("Enter text for file1.txt:");
            string input1 = Console.ReadLine() ?? string.Empty; 
            using (StreamWriter writer1 = new StreamWriter(filePath1))
            {
                writer1.Write(input1);
            }

            Console.WriteLine("Enter text for file2.txt:");
            string input2 = Console.ReadLine() ?? string.Empty; 
            using (StreamWriter writer2 = new StreamWriter(filePath2))
            {
                writer2.Write(input2);
            }

            string content1, content2;
            using (StreamReader reader1 = new StreamReader(filePath1))
            {
                content1 = reader1.ReadToEnd();
            }
            using (StreamReader reader2 = new StreamReader(filePath2))
            {
                content2 = reader2.ReadToEnd();
            }

            Console.WriteLine(content1 == content2 ? "The files are identical." : "The files are different.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.GetType()} - {ex.Message}");
        }
    }
}