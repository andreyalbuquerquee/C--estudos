using Course.Entities;
using Course.Entities.Enums;
using System.Globalization;

namespace Course
{

    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> list = new List<Shape>();

            Console.WriteLine("Enter the number of shaped: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++) 
            {
                Console.WriteLine($"Shape #{i} data: ");
                Console.WriteLine("Rectangle or circle? (r/c): ");
                char shapeType = char.Parse(Console.ReadLine());

                Console.WriteLine("Color: (Black/Blue/Red)");
                Color shapeColor = Enum.Parse<Color>(Console.ReadLine());

                if(shapeType == 'r') 
                {
                    Console.WriteLine("Width: ");
                    double rectangleWidth = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.WriteLine("Height: ");
                    double rectangle = double.Parse (Console.ReadLine(), CultureInfo.InvariantCulture);

                    list.Add(new Rectangle(rectangle, rectangleWidth, shapeColor));
                }
                else 
                {
                    Console.WriteLine("Radius: ");
                    double circleRadius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Circle(circleRadius, shapeColor));
                }
            }

            Console.WriteLine();
            Console.WriteLine("Shapes areas: ");
            foreach (Shape shape in list) 
            {
                Console.WriteLine($"{shape.Area().ToString("F2", CultureInfo.InvariantCulture)}");
            }

        }
    }
}
