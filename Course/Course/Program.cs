

using System.Globalization;

namespace Course {

    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Informe o primeiro lado do triângulo X:");
            int firstSideX = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o segundo lado do triângulo X:");
            int secondSideX = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o primeiro lado do triângulo Y:");
            int firstSideY = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o segundo lado do triângulo Y:");
            int secondSideY = int.Parse(Console.ReadLine());

            double xArea = ((double)firstSideX * secondSideX) / 2;

            double yArea = ((double)firstSideY * secondSideY) / 2;

            string biggerTriangle = xArea > yArea ? "X" : "Y";

            Console.WriteLine($"O triângulo {biggerTriangle} é o maior!");
            Console.WriteLine($"Área X: {xArea:F2}");
            Console.WriteLine($"Área Y: {yArea:F2}");



        }
    }
}
