

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\andre\OneDrive\Documents\C# estudos";

            try
            {
                IEnumerable<string> folders = Directory.EnumerateFileSystemEntries(path, "*.cs", SearchOption.AllDirectories);
                foreach (string folder in folders) 
                {
                    Console.WriteLine(folder);
                }
                Directory.CreateDirectory(path + @"\teste");

            }
            catch (IOException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
