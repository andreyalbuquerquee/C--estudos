

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Users\andre\OneDrive\Documents\C# estudos\file1.txt";

            try
            {
                using (FileStream fs = new FileStream(sourcePath, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            Console.WriteLine(sr.ReadLine());
                        }
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
