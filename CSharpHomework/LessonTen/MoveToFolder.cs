using System;
using System.IO;

class MoveToFolder
{
    public static void Execute()
    {
        // Important! In Windows in case a relative path is used instead of an absolute one, the Path should be set Relative to
        // Bin folder, so we have to navigate 3 times UP to the project root from bin\Debug\net8.0\
        string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

        string sourceFolder = Path.Combine(projectDirectory, "SourceFolder");
        string backupFolder = Path.Combine(projectDirectory, "BackupFolder");

        if (!Directory.Exists(sourceFolder))
        {
            Directory.CreateDirectory(sourceFolder);
            File.WriteAllText(Path.Combine(sourceFolder, "file1.txt"), "This is file 1");
            File.WriteAllText(Path.Combine(sourceFolder, "file2.txt"), "This is file 2");
        }

        if (!Directory.Exists(backupFolder))
        {
            Directory.CreateDirectory(backupFolder);
        }

        string[] files = Directory.GetFiles(sourceFolder);
        foreach (string file in files)
        {
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(backupFolder, fileName);
            File.Move(file, destFile);
        }

        Console.WriteLine("Files in BackupFolder:");
        string[] movedFiles = Directory.GetFiles(backupFolder);
        foreach (string file in movedFiles)
        {
            Console.WriteLine(Path.GetFileName(file));
        }
    }
}