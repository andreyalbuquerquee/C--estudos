using System.IO;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Users\andre\OneDrive\Documents\C# estudos\file1.txt";
            string targetPath = @"C:\Users\andre\OneDrive\Documents\C# estudos\file2.txt";

            try
            {
                FileInfo fileInfo = new FileInfo(sourcePath);
                fileInfo.CopyTo(targetPath);
                string[] fileLines = File.ReadAllLines(sourcePath);
                Console.WriteLine($"Primeira linha: {fileLines[0]}");
                Console.WriteLine($"Segunda linha: {fileLines[1]}");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        
        }
    }
}
