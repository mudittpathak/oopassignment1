using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances
{
    public abstract class Appliances
    {
        //getter-setter
        public long ItemNumber { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public double Wattage { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        protected Appliances(long itemNumber, string brand, int quantity, double wattage, string color, double price)
        {
            ItemNumber = itemNumber;
            Brand = brand;
            Quantity = quantity;
            Wattage = wattage;
            Color = color;
            Price = price;
        }
        //tostring
        //tostring
        public override string ToString()
        {
            return $"ItemNumber : {ItemNumber}\nBrand : {Brand}\nQuantity : {Quantity}\nWattage : {Wattage}\nColor : {Color}\nPrice : {Price}\n";
        }
    }
}
