using Course.Entities;

namespace Course
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Room number");
            int roomNumber = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Check-in date (dd/MM/yyyy):");
            DateTime checkIn = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Check-out date (dd/MM/yyyy):");
            DateTime checkOut = DateTime.Parse(Console.ReadLine());

            Reservation reservation = new Reservation(roomNumber, checkIn, checkOut);

            Console.WriteLine(reservation);

            Console.WriteLine("Enter data to update the reservation: ");
            Console.WriteLine("Check-in date (dd/MM/yyyy):");
            checkIn = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Check-out date (dd/MM/yyyy):");
            checkOut = DateTime.Parse(Console.ReadLine());

            string error = reservation.UpdateDates(checkIn, checkOut);

            if (error != null) 
            {
                Console.WriteLine(error);
            }
            else
            {
                Console.WriteLine(reservation);
            }

        }
    }
}
