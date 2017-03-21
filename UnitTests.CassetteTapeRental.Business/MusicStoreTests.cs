using CassetteTapeRental.Business;
using NUnit.Framework;

namespace UnitTests.CassetteTapeRental.Business
{
	[TestFixture]
	public class MusicStoreTests
	{
		private CassetteTape _hairBandTape;
		private CassetteTape _hardRockTape;
		private CassetteTape _classicRockTape;

		private Customer _customer;

		[SetUp]
		public void MySetUp()
		{
			_hairBandTape = new CassetteTape("Def Leppard: Pyromania", PriceCodes.HairMetal);
			_hardRockTape = new CassetteTape("AC/DC: Back in Black", PriceCodes.HardRock);
			_classicRockTape = new CassetteTape("Led Zeppelin: Zoso", PriceCodes.ClassicRock);

			_customer = new Customer("Bryant Smith");
		}

		[Test]
		public void RentedRorTheWeekend()
		{
			const int numberOfDays = 2;
			RentThreeCassetteTapesForBryant(numberOfDays);
			Assert.That(_customer.Statement(), Is.EqualTo(
				"Rental record for Bryant Smith\n" +
			    "\tDef Leppard: Pyromania\t1.5\n" +
			    "\tAC/DC: Back in Black\t6\n" +
			    "\tLed Zeppelin: Zoso\t2\n" +
			    "Amount owed is 9.5\n" +
			    "You earned 4 frequent renter points."));
		}

//		[Test]
//		public void OneWeekRentals_HtmlStatement()
//		{
//			const int numberOfDays = 7;
//			RentThreeCassetteTapesForBryant(numberOfDays);
//			Assert.That(_customer.HTMLStatement(), Is.EqualTo(
//				"<H1>Rental record for <EM>Bryant Smith</EM></H1><P>\n" +
//				"Def Leppard: Pyromania: 7.5<BR>\n" +
//				"AC/DC: Back in Black: 21<BR>\n" +
//				"Led Zeppelin: Zoso: 9.5<BR>\n" +
//				"<P>Amount owed is <EM>38</EM><P>\n" +
//				"You earned <EM>4</EM> frequent renter points.<P>"));
//		}

		private void RentThreeCassetteTapesForBryant(int numberOfDays)
		{
			var rental1 = new Rental(_hairBandTape, numberOfDays);
			var rental2 = new Rental(_hardRockTape, numberOfDays);
			var rental3 = new Rental(_classicRockTape, numberOfDays);
			_customer.AddRental(rental1);
			_customer.AddRental(rental2);
			_customer.AddRental(rental3);
		}
	}
}
