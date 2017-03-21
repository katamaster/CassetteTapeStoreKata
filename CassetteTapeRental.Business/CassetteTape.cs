namespace CassetteTapeRental.Business
{
    public enum PriceCodes
    {
        ClassicRock, HardRock, HairMetal
    }

    public class CassetteTape
    {
	    public CassetteTape(string title, PriceCodes priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

	    public PriceCodes PriceCode { get; set; }

	    public string Title { get; private set; }
    }
}
