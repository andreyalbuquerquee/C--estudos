using Course.Entities;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter full file path: ");
            string path = Console.ReadLine();
            HashSet<LogRecord> logRecords = new HashSet<LogRecord>();
            
            try
            { 
                using (StreamReader sr = new StreamReader(path)) 
                {
                    while (!sr.EndOfStream)
                    {
                        string[] logInfos = sr.ReadLine().Split(" ");

                        string name = logInfos[0];
                        DateTime accessTime = DateTime.Parse(logInfos[1]);

                        logRecords.Add(new LogRecord(name, accessTime));
                    }

                    Console.WriteLine($"Total users: {logRecords.Count}");
                }
            }
            catch (IOException ex) 
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
