

using Course.Entities;
using Course.Entities.Enums;
using System.Globalization;

namespace Course {

    class Program {
        static void Main(string[] args) {

            Order order = new Order {
                Id = 1080,
                Moment = DateTime.Now,
                Status = OrderStatus.PendingPayment
            };

            Console.WriteLine(order);

            string txt = OrderStatus.PendingPayment.ToString();

            Console.WriteLine(txt);

            OrderStatus orderStatus = Enum.Parse<OrderStatus>("Shipped");

            Console.WriteLine(orderStatus);


        }
    }
}
