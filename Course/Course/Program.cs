

using System.Globalization;

namespace Course {

    class Program {
        static void Main(string[] args) {

            Product p = new Product();
            
            Console.WriteLine("Digite os dados do produto: ");
            
            Console.WriteLine("Nome: ");
            p.Name = Console.ReadLine();
            
            Console.WriteLine("Digite o preço: ");
            p.Price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Digite as unidades em estoque: ");
            p.Unity = int.Parse(Console.ReadLine());

            Console.WriteLine($"Dados do produto: \n{p}");

            Console.WriteLine("Digite as unidades a serem adicionadas em estoque: ");
            p.Unity += int.Parse(Console.ReadLine());

            Console.WriteLine($"Dados atualizados do produto: \n{p}");

            Console.WriteLine("Digite as unidades a serem removidas do estoque: ");
            p.Unity -= int.Parse(Console.ReadLine());

            Console.WriteLine($"Dados atualizados do produto: \n{p}");
        }
    }
}
