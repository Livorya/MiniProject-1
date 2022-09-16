

namespace MiniProject_1
{
    internal class Computer : Asset
    {
        public Computer(string brand, string model, Country office, DateTime purchaseDate, int price) : base(brand, model, office, purchaseDate, price) { }

        public override string ToString()
        {   //Method override of ToString that is used in the PrintDetailsPadded method in the base class
            return "Computer";
        }
    }
}
