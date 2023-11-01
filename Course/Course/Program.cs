

using Course.Entities;
using Course.Entities.Enums;
using System.Globalization;

namespace Course {

    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Enter deparment's name");
            string departmentName = Console.ReadLine();

            Console.WriteLine("Enter worker data: ");
            Console.WriteLine("Name: ");
            string workerName = Console.ReadLine();
            
            Console.WriteLine("Level: (Junior, MidLevel, Senior)");
            WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.WriteLine("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department department = new Department(departmentName);
            Worker worker = new Worker(workerName, workerLevel, baseSalary, department);

            Console.WriteLine("How many contracts for this worker?");
            int numberOfContracts = int.Parse(Console.ReadLine());

            for(int i = 1; i <= numberOfContracts; i++) {
                Console.WriteLine($"Enter the #{i} contract: ");
                Console.WriteLine("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.WriteLine("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract workerHourContract = new HourContract(date, valuePerHour, hours);

                worker.AddContract(workerHourContract);
            }

            Console.WriteLine();
            Console.WriteLine("Enter month and year to calculate income (MM/YYYY): ");
            string monthYearInput = Console.ReadLine();
            string[] monthAndYear = monthYearInput.Split("/");
            int month = int.Parse(monthAndYear[0]);
            int year = int.Parse(monthAndYear[1]);

            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {monthYearInput}: {worker.Income(year, month)}");



        }
    }
}
