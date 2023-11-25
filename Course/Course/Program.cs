
using Course.Entities;

using System.Linq;
using System.Threading.Channels;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 3, 4, 5 };

            var result = numbers.Where(number => number % 2 == 0).Select(x => x * 10);

            foreach (int number in result) 
            {
                Console.WriteLine(number);
            }
        }


    }
}
