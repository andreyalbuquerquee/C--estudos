namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintService printService = new PrintService();

            Console.Write("How many values?");
            int amountOfValues = int.Parse(Console.ReadLine());

            for (int i = 0; i < amountOfValues; i++) 
            {
                printService.AddValue(int.Parse(Console.ReadLine()));
            }

            printService.Print();
            Console.WriteLine("First: " + printService.First());
        }
    }
}
