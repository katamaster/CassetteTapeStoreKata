using System.Collections;

namespace CassetteTapeRental.Business
{
	public class Customer
	{
		private readonly string _name;
		private readonly ArrayList _rentals = new ArrayList();
		
		public Customer(string name)
		{
			_name = name;
		}
		
		public string Name
		{
			get { return _name; }
		}
		
		public void AddRental(Rental arg)
		{
			_rentals.Add(arg);
		}

		public string Statement()
		{
			double totalAmount = 0;
			int frequentRenterPoints = 0;
			IEnumerator rentals = _rentals.GetEnumerator();
			string result = "Rental record for " + _name + "\n";
			while (rentals.MoveNext())
			{
				double thisAmount = 0;
				var each = (Rental)rentals.Current;
				switch (each.CassetteTapeRented.PriceCode)
				{
					case PriceCodes.ClassicRock:
						thisAmount += 2;
						if (each.DaysRented > 2)
						{
							thisAmount += (each.DaysRented - 2) * 1.5;
						}
						break;
					case PriceCodes.HardRock:
						thisAmount += each.DaysRented * 3;
						break;
					case PriceCodes.HairMetal:
						thisAmount += 1.5;
						if (each.DaysRented > 3)
						{
							thisAmount += (each.DaysRented - 3) * 1.5;
						}
						break;
				}
				frequentRenterPoints++;
				if ((each.CassetteTapeRented.PriceCode == PriceCodes.HardRock) && (each.DaysRented > 1))
				{
					frequentRenterPoints++;
				}
				result += "\t" + each.CassetteTapeRented.Title + "\t" + thisAmount + "\n";
				totalAmount += thisAmount;
			}
			result += "Amount owed is " + totalAmount + "\n";
			result += "You earned " + frequentRenterPoints + " frequent renter points.";
			return result;
		}
	}
}
