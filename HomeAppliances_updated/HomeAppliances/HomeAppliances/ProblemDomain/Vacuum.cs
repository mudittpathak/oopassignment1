using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances
{
    public class Vacuum : Appliances
    {
        public Vacuum(long intemNumber, string brand, int quantity, double wattage, string color, double price, string grade, int voltage) : base(intemNumber, brand, quantity, wattage, color, price)
        {
            Grade = grade;
            Voltage = voltage;
        }
        //getter-setter
        public string Grade { get; set; }
        public int Voltage { get; set; }
        // tostring
        public override string ToString()
        {
            return $"{base.ToString()}Grade : {Grade}\nVoltage : {Voltage}\n";
        }
    }
}
