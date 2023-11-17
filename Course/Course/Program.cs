using System.IO;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Users\andre\OneDrive\Documents\C# estudos\file1.txt";
            StreamReader sr = null;

            try
            {
                sr = File.OpenText(sourcePath);
                
                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }  
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sr != null) sr.Close();
            }
        }
    }
}
