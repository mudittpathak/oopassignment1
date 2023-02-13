using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances
{
    public class Refrigerator : Appliances
    {
        public Refrigerator(long intemNumber, string brand, int quantity, double wattage, string color, double price, int numberOfDoors, int height, int width) : base(intemNumber, brand, quantity, wattage, color, price)
        {
            NumberOfDoors = numberOfDoors;
            Height = height;
            Width = width;
        }
        //getter-setter
        public int NumberOfDoors { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        //tostring
        public override string ToString()
        {
            return $"{base.ToString()}NumberOfDoors : {NumberOfDoors}\nHeight : {Height}\nWidth : {Width}\n";
        }
    }
}
