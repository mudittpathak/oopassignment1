using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances
{
    public class Dishwasher :Appliances
    {
        public Dishwasher(long intemNumber, string brand, int quantity, double wattage, string color, double price, string feature, string soundRating) : base(intemNumber, brand, quantity, wattage, color, price)
        {
            Feature = feature;
            SoundRating = soundRating;
        }
        //getter-setter
        public string Feature { get; set; }
        public string SoundRating { get; set; }
        // tostring
        public override string ToString()
        {
            return $"{base.ToString()}SoundRating : {SoundRating}\nFeature : {Feature}\n";
        }
    }
}
