
namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(2023, 11, 22, 20, 0, 0);
            Console.WriteLine(dt.ElapsedTime());
        }
    }
}
