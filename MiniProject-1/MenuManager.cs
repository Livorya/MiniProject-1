

namespace MiniProject_1
{
    internal static class MenuManager
    {
        public static void UseStartMenu(List<Asset> assets)
        {   //Method that set actions in motion based on user input
            int menuChoice;
            do
            {
                menuChoice = StartMenuChooser();
                switch (menuChoice)
                {
                    case 1:  //Enter a new asset
                        assets.Add(CreateAssetMenu());
                        break;
                    case 2:  //View assets list
                        Utilities.PrintAssetsListDetails(assets);
                        break;
                }
            } while (menuChoice != 0);  //Quit program
        }
        public static int StartMenuChooser()
        {   //Method that allows the user to choose a menu item and then returns a valid choice
            Console.WriteLine("\nWelcome to Asset Tracking!");
            while (true)
            {
                WriteColoredNumberInParanthese(1, ConsoleColor.Cyan);
                Console.WriteLine(" Enter a new asset");
                WriteColoredNumberInParanthese(2, ConsoleColor.Cyan);
                Console.WriteLine(" View assets list");
                WriteColoredNumberInParanthese(0, ConsoleColor.Red);
                Console.WriteLine(" Quit program");

                Console.Write("Your choice: ");
                string input = Console.ReadLine();
                if (input == "0" || input == "1" || input == "2")
                {
                    return int.Parse(input);
                }
                else
                {
                    InvalidEntryMessage();
                }
            }
        }
        public static void WriteColoredNumberInParanthese(int number, ConsoleColor color)
        {   //Method that takes a number and a color and then writes the number colored inside parantheses
            Console.Write("(");
            Console.ForegroundColor = color;
            Console.Write(number);
            Console.ResetColor();
            Console.Write(")");
        }
        public static Asset CreateAssetMenu()
        {   //Method that asks the user for the necessary information to create a new asset and the returns the asset
            int assetType = ChooseAssetType();
            Console.Write("Enter a Brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter a Model: ");
            string model = Console.ReadLine();
            Country office = ChooseAssetOffice();
            DateTime purchaseDate = EnterAssetPurchaseDate();
            int price = EnterAssetPriceUSD();
            
            if (assetType == 1)
            {
                return new Computer(brand, model, office, purchaseDate, price);
            }
            else
            {
                return new Phone(brand, model, office, purchaseDate, price);
            }
        }
        private static int ChooseAssetType()
        {   //Metod that asks the user to choose a type of asset and then returns an int that represent the choice
            while (true)
            {
                Console.WriteLine("Choose a type of asset to add");
                WriteColoredNumberInParanthese(1, ConsoleColor.Green);
                Console.WriteLine(" Computer");
                WriteColoredNumberInParanthese(2, ConsoleColor.Green);
                Console.WriteLine(" Phone");

                string input = Console.ReadLine();
                if (input == "1" || input == "2")
                {
                    return int.Parse(input);
                }
                else
                {
                    InvalidEntryMessage();
                }
            }
        }
        private static Country ChooseAssetOffice()
        {   //Method that asks the user to choose an office and then returns the country enum
            while (true)
            {
                Console.WriteLine("Choose Office");
                WriteColoredNumberInParanthese(1, ConsoleColor.Magenta);
                Console.WriteLine(" England");
                WriteColoredNumberInParanthese(2, ConsoleColor.Magenta);
                Console.WriteLine(" Sweden");
                WriteColoredNumberInParanthese(3, ConsoleColor.Magenta);
                Console.WriteLine(" USA");

                string input = Console.ReadLine();
                if (input == "1" || input == "2" || input == "3")
                {
                    return (Country)int.Parse(input);  //Takes advantage of the int representation of the country enum
                }
                else
                {
                    InvalidEntryMessage();
                }
            }
        }
        private static DateTime EnterAssetPurchaseDate()
        {   //Method that asks the user for a purchase date and makes sure it is in a correct format and then returns the date
            while (true)
            {
                Console.Write("Enter a purchase date: ");
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out DateTime date))
                {
                    return date;
                }
                else
                {
                    InvalidEntryMessage();
                    Console.WriteLine("Valid date format is YYYY-MM-DD");
                }
            }
        }
        private static int EnterAssetPriceUSD()
        {   //Method that asks the user for a price input and ensures that the entry is valid and then returns the price
            while (true)
            {
                Console.Write("Enter a price in USD: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    return value;
                }
                else
                {
                    InvalidEntryMessage();
                }
            }
        }
        private static void InvalidEntryMessage()
        {   //Method that writes an error message to the console
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid entry, please try again");
            Console.ResetColor();
        }
    }
}
