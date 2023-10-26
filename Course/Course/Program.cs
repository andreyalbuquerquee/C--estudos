

using System.Globalization;

namespace Course {

    class Program {
        static void Main(string[] args) {

            Triangle x, y;

            x = new Triangle();
            y = new Triangle();
            
            Console.WriteLine("Informe a altura do triângulo X:");
            x.Height = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe a base do triângulo X:");
            x.Base = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe a altura do triângulo Y:");
            y.Height = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe a base do triângulo Y:");
            y.Base = int.Parse(Console.ReadLine());

            double xArea = x.calculateArea();

            double yArea = y.calculateArea();

            string biggerTriangle = xArea > yArea ? "X" : "Y";

            Console.WriteLine($"O triângulo {biggerTriangle} é o maior!");
            Console.WriteLine($"Área X: {xArea:F2}");
            Console.WriteLine($"Área Y: {yArea:F2}");



        }
    }
}
