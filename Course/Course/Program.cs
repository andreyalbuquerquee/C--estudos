using Course.Entities;

namespace Course {

    class Program {
        static void Main(string[] args) {

            BusinessAccount businessAccount = new BusinessAccount(8010, "Andrey", 100.0, 500.0);

            Console.WriteLine(businessAccount.Balance);

            businessAccount.Balance = 200; // da erro isso, só da pra alterar o saldo por dentro da classe businessAccount
        }
    }
}
