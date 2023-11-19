
namespace Course.Services
{
    class BrazilTaxService : ITaxService
    {
        public double Tax(double amount)
        {
            if (amount > 100)
            {
                return amount * 0.15;
            }
            return amount * 0.2;
        }
    }
}
