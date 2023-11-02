using Course.Entities;

namespace Course {

    class Program {
        static void Main(string[] args) {

            Account acc = new Account(1001, "Andrey", 0.0);

            BusinessAccount bacc = new BusinessAccount(1002, "Brian", 0.0, 500.0);

            // UPCASTING
            Account acc1 = bacc;
            Account acc2 = new BusinessAccount(1003, "João", 0.0, 200.0);
            Account acc3 = new SavingsAccount(1004, "Caju", 0.0, 0.01);

            // DOWNCASTING
            BusinessAccount acc4 = (BusinessAccount)acc2;

            // BusinessAccount acc5 = (BusinessAccount)acc3; Da erro pq BusinessAccount n é compatível com SavingsAccount
            if (acc3 is BusinessAccount) // Vai dar false
            {
                BusinessAccount acc5 = (BusinessAccount)acc3;
                BusinessAccount acc6 = acc3 as BusinessAccount; // da pra fazer assim tb o casting
            }
        }
    }
}
