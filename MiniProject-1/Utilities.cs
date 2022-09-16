

namespace MiniProject_1
{
    internal static class Utilities
    {
        public static void PrintAssetsListDetails(List<Asset> assets)
        {   //Method that writes the detail head and all items in the assets list (sorted by office and then by date) to console
            int padding = 13;

            List<Asset> assetsSorted = assets.OrderBy(a => a.Office.ToString()).ThenBy(a => a.PurchesDate).ToList();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Type".PadRight(padding) + "Brand".PadRight(padding) + "Model".PadRight(padding) + "Office".ToString().PadRight(padding) + "Purches".PadRight(padding) + "Price USD".PadRight(padding) + "Currency".PadRight(padding) + "Local Price");
            Console.WriteLine("----".PadRight(padding) + "-----".PadRight(padding) + "-----".PadRight(padding) + "------".ToString().PadRight(padding) + "-------".PadRight(padding) + "---------".PadRight(padding) + "--------".PadRight(padding) + "-----------");

            foreach (var asset in assetsSorted)
            {
                Console.ForegroundColor = CloseToEndDateColorMark(asset.PurchesDate);
                asset.PrintDetailsPadded(padding);
                Console.ResetColor();
            }
        }
        public static string GetCurrency(Country country)
        {   //Method that returns the type of currency for a given country/office
            switch (country)
            {
                case Country.Sweden:
                    {
                        return "SEK";
                    }
                case Country.England:
                    {
                        return "GBP";
                    }
                default:
                    {
                        return "USD";
                    }
            }
        }
        public static double ConvertPrice(Country country, int priceUSD)
        {   //Method that convert the USD price to the currency of entered country/office and returns the converted price
            switch (country)
            {
                case Country.Sweden:
                    {
                        return priceUSD * 10.42;  //1 USD = 10,42 SEK
                    }
                case Country.England:
                    {
                        return priceUSD * 0.85;  //1 USD = 0,85 GBP
                    }
                default:
                    {
                        return priceUSD;
                    }
            }
        }
        public static ConsoleColor CloseToEndDateColorMark(DateTime purchaseDate)
        {   //Method that checks how close a date is to three years and returns a color based on the result
            TimeSpan time = DateTime.Now - purchaseDate;  //The time span between the purchase date and today

            int ThreeYears = 365 * 3;
            int ThreeMonthsBeforeThreeYears = ThreeYears - 30 * 3;
            int SixMonthsBeforeThreeYeras = ThreeYears - 30 * 6;

            if (time.Days > ThreeYears)
            {
                return ConsoleColor.DarkRed;
            }
            else if (time.Days > ThreeMonthsBeforeThreeYears)
            {
                return ConsoleColor.Red;
            }
            else if (time.Days > SixMonthsBeforeThreeYeras)
            {
                return ConsoleColor.Yellow;
            }
            else
            {
                return ConsoleColor.White;
            }
        }
    }
}
