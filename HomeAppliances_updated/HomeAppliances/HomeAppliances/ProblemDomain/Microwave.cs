using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances
{
    public class Microwave : Appliances
    {
        public Microwave(long intemNumber, string brand, int quantity, double wattage, string color, double price, double capacity, string roomType) : base(intemNumber, brand, quantity, wattage, color, price)
        {
            Capacity = capacity;
            RoomType = roomType;
        }
        //getter-setter
        public double Capacity { get; set; }
        public string RoomType { get; set; }
        //tostring
        public override string ToString()
        {
            return $"{base.ToString()}Capacity : {Capacity}\nRoomType : {RoomType}\n";
        }
    }
}
