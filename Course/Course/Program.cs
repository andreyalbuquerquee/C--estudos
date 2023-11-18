

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
                string[] lines = File.ReadAllLines(sourcePath);
                using (StreamWriter sw = File.AppendText(targetPath)) 
                {
                    foreach (string line in lines) 
                    {
                        sw.WriteLine(line.ToUpper());
                    }
                }

            }
            catch (IOException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
