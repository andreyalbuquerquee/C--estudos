

using System.Globalization;

namespace Course {

    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Digite a quantidade de alturas que deseja informar: ");
            int n = int.Parse(Console.ReadLine());

            double[] heights = new double[n];

            Console.WriteLine("Agora digite as alturas: ");

            for (int i = 0; i < n; i++) {
                heights[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            }

            Console.WriteLine($"Média das alturas é: {heights.Average().ToString("F2", CultureInfo.InvariantCulture)}");

        }
    }
}
