namespace CassetteTapeRental.Business
{
    public class Rental
    {
        private CassetteTape _cassetteTapeRented;
        private int _daysRented;
        
		public Rental(CassetteTape CassetteTapeRented, int daysRented)
        {
            _cassetteTapeRented = CassetteTapeRented;
            _daysRented = daysRented;
        }
        
		public int DaysRented
        {
            get { return _daysRented; }
        }
        
		public CassetteTape CassetteTapeRented
        {
            get { return _cassetteTapeRented; }
        }
    }
}