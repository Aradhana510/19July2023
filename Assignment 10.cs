using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose operation:");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Read");
        Console.WriteLine("3. Append");
        Console.WriteLine("4. Delete");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Enter the file name: ");
                string createFileName = Console.ReadLine();
                Console.Write("Enter the content: ");
                string content = Console.ReadLine();
                CreateFile(createFileName, content);
                break;

            case 2:
                Console.Write("Enter the file name to read: ");
                string readFileName = Console.ReadLine();
                ReadFile(readFileName);
                break;

            case 3:
                Console.Write("Enter the file name to append: ");
                string appendFileName = Console.ReadLine();
                Console.Write("Enter the content to append: ");
                string appendContent = Console.ReadLine();
                AppendToFile(appendFileName, appendContent);
                break;

            case 4:
                Console.Write("Enter the file name to delete: ");
                string deleteFileName = Console.ReadLine();
                DeleteFile(deleteFileName);
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void CreateFile(string fileName, string content)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(content);
            }
            Console.WriteLine($"File '{fileName}' created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating file: {ex.Message}");
        }
    }

    static void ReadFile(string fileName)
    {
        try
        {
            string content = File.ReadAllText(fileName);
            Console.WriteLine($"Content of '{fileName}':\n{content}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }

    static void AppendToFile(string fileName, string content)
    {
        try
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                writer.Write(content);
            }
            Console.WriteLine($"Content appended to '{fileName}' successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error appending to file: {ex.Message}");
        }
    }

    static void DeleteFile(string fileName)
    {
        try
        {
            File.Delete(fileName);
            Console.WriteLine($"File '{fileName}' deleted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting file: {ex.Message}");
        }
    }
}
