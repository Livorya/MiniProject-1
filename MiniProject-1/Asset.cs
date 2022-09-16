

namespace MiniProject_1
{
    internal abstract class Asset
    {
        public Asset(string brand, string model, Country office, DateTime purchesDate, int price)
        {   //Constructor that sets the values that all inherited classes use to reduce redundancy
            Brand = brand;
            Model = model;
            Office = office;
            PurchesDate = purchesDate;
            PriceUSD = price;
        }

        public string Brand { get; protected set; }
        public string Model { get; protected set; }
        public DateTime PurchesDate { get; protected set; }
        public Country Office { get; protected set; }
        public int PriceUSD { get; protected set; }

        public void PrintDetailsPadded(int padding)
        {   //Method that prints the details in a predetermined way that all inherited classes use
            Console.WriteLine(ToString().PadRight(padding) + Brand.PadRight(padding) + Model.PadRight(padding) + Office.ToString().PadRight(padding) + PurchesDate.ToShortDateString().PadRight(padding) + PriceUSD.ToString().PadRight(padding) + Utilities.GetCurrency(Office).PadRight(padding) + Utilities.ConvertPrice(Office, PriceUSD));
        }
    }
}
