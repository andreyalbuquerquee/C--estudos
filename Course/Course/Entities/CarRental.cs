namespace Course.Entities
{
    class CarRental
    {
        public DateTime StartDate { get; set; }
        public DateTime Finish { get; set; }
        public Vehicle Vehicle { get; set; }
        public Invoice Invoice { get; set; }

        public CarRental(DateTime startDate, DateTime finish, Vehicle vehicle)
        {
            StartDate = startDate;
            Finish = finish;
            Vehicle = vehicle;
            Invoice = null;
        }
    }
}
