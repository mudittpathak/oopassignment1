using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//submitted by- Mudit and Nishant
namespace HomeAppliances
{
    internal class Program
    {
        //list
        static List<Appliances> Appliances = new List<Appliances>();
        static string fileName = "appliances.txt";
        static void Main(string[] args)
        {
            ParseTextFile();
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Welcome to Modern Appliances,How may we assist you?");
                Console.WriteLine(" 1. Check out appliance");
                Console.WriteLine(" 2. Find appliances by brand");
                Console.WriteLine(" 3. Display appliances by type");
                Console.WriteLine(" 4. Produce random appliance list");
                Console.WriteLine(" 5. Save & exit");
                Console.Write("Enter option:");

                int ch = int.Parse(Console.ReadLine());
                Console.Write("\n");

                if (ch == 1)
                {
                    PurchaseAppliance();
                }
                else if (ch == 2)
                {
                    FindByBrand();
                }
                else if (ch == 3)
                {
                    ProductsByType();
                }
                else if (ch == 4)
                {
                    ProduceRandom();
                }
                else if (ch == 5)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("No items found with this item number");
                }
            }

        }

        static void ParseTextFile()
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                if (lines.Any())
                {
                    foreach (string line in lines)
                    {
                        string[] tokens = line.Split(';');

                        if (tokens[0].StartsWith("1"))
                        {
                            Refrigerator refrigerator = new Refrigerator(Convert.ToInt64(tokens[0]), tokens[1],
                                Convert.ToInt32(tokens[2]), Convert.ToDouble(tokens[3]), tokens[4], Convert.ToDouble(tokens[5]),
                                Convert.ToInt32(tokens[6]), Convert.ToInt32(tokens[7]), Convert.ToInt32(tokens[8]));

                            Appliances.Add(refrigerator);
                        }
                        else if (tokens[0].StartsWith("2"))
                        {
                            Vacuum vacuum = new Vacuum(Convert.ToInt64(tokens[0]), tokens[1],
                                Convert.ToInt32(tokens[2]), Convert.ToDouble(tokens[3]), tokens[4], Convert.ToDouble(tokens[5]),
                                tokens[6], Convert.ToInt32(tokens[7]));

                            Appliances.Add(vacuum);
                        }
                        else if (tokens[0].StartsWith("3"))
                        {
                            Microwave microwave = new Microwave(Convert.ToInt64(tokens[0]), tokens[1],
                                Convert.ToInt32(tokens[2]), Convert.ToDouble(tokens[3]), tokens[4], Convert.ToDouble(tokens[5]),
                                Convert.ToDouble(tokens[6]), tokens[7]);

                            Appliances.Add(microwave);
                        }
                        else if (tokens[0].StartsWith("4") || (tokens[0].StartsWith("5")))
                        {
                            Dishwasher dishwasher = new Dishwasher(Convert.ToInt64(tokens[0]), tokens[1],
                                Convert.ToInt32(tokens[2]), Convert.ToDouble(tokens[3]), tokens[4], Convert.ToDouble(tokens[5]),
                                tokens[6], tokens[7]);

                            Appliances.Add(dishwasher);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"{fileName} file is not found");
            }
        }

        static void PurchaseAppliance()
        {
            Console.WriteLine("Enter the item number of an appliance: ");
            long itemNumber = Convert.ToInt64(Console.ReadLine());

            if (Appliances.Any(x => x.ItemNumber == itemNumber))
            {
                if (itemNumber.ToString().StartsWith("1"))
                {
                    Refrigerator refrigerator = (Refrigerator)Appliances.FirstOrDefault(x => x.ItemNumber == itemNumber);

                    if (refrigerator.Quantity > 0)
                    {
                        Console.WriteLine($"Appliance {refrigerator.ItemNumber} has been checked out.");
                        refrigerator.Quantity--;
                    }
                    else
                    {
                        Console.WriteLine("The appliance is not available to be checked out.");
                    }
                }
                else if (itemNumber.ToString().StartsWith("2"))
                {
                    Vacuum vaccume = (Vacuum)Appliances.FirstOrDefault(x => x.ItemNumber == itemNumber);

                    if (vaccume.Quantity > 0)
                    {
                        Console.WriteLine($"Appliance {vaccume.ItemNumber} has been checked out.");
                        vaccume.Quantity--;
                    }
                    else
                    {
                        Console.WriteLine("The appliance is not available to be checked out.");
                    }
                }
                else if (itemNumber.ToString().StartsWith("3"))
                {
                    Microwave microwave = (Microwave)Appliances.FirstOrDefault(x => x.ItemNumber == itemNumber);

                    if (microwave.Quantity > 0)
                    {
                        Console.WriteLine($"Appliance {microwave.ItemNumber} has been checked out.");
                        microwave.Quantity--;
                    }
                    else
                    {
                        Console.WriteLine("The appliance is not available to be checked out.");
                    }
                }
                else if (itemNumber.ToString().StartsWith("4"))
                {
                    Dishwasher dish = (Dishwasher)Appliances.FirstOrDefault(x => x.ItemNumber == itemNumber);

                    if (dish.Quantity > 0)
                    {
                        Console.WriteLine($"Appliance {dish.ItemNumber} has been checked out.");
                        dish.Quantity--;
                    }
                    else
                    {
                        Console.WriteLine("The appliance is not available to be checked out.");
                    }
                }

            }
            else
            {
                Console.WriteLine("No appliances found with that item number.");
            }
        }

        static void FindByBrand()
        {
            Console.WriteLine("Enter brand to search for: ");
            string brand = Console.ReadLine();
            Console.WriteLine("Matching Appliances:");

            var appliancesByBrand = Appliances.Where(x => x.Brand.ToLower() == brand.ToLower());

            foreach (var item in appliancesByBrand)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void ProduceRandom()
        {
            Console.WriteLine("Enter number of appliances: ");
            int itemNumbers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Random appliances: ");
            Random random = new Random();
            for (int i = 0; i < itemNumbers; i++)
            {
                int index = random.Next(0, Appliances.Count);

                Console.WriteLine(Appliances[index].ToString());
            }
        }

        static void ProductsByType()
        {
            Console.WriteLine("Appliance Types : ");
            Console.WriteLine("1. Refrigerators");
            Console.WriteLine("2. Vacuums");
            Console.WriteLine("3. Microwaves");
            Console.WriteLine("4. Dishwashers");
            Console.WriteLine("Enter type of appliance:");

            int type = Convert.ToInt32(Console.ReadLine());

            switch (type)
            {
                case 1:
                    Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
                    int doors = Convert.ToInt32(Console.ReadLine());
                    var filteredRefrigerators = Appliances.OfType<Refrigerator>().ToList();

                    Console.WriteLine($"Matching Refrigerators with {doors} doors:\n");
                    foreach (var item in filteredRefrigerators)
                    {
                        if (item.NumberOfDoors == doors)
                        {
                            Console.WriteLine(item.ToString());
                        }
                    }

                    break;
                case 2:
                    Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high):");
                    int voltage = Convert.ToInt32(Console.ReadLine());

                    var filteredVacuums = Appliances.OfType<Vacuum>().ToList();

                    Console.WriteLine($"Matching Vacuums with {voltage} voltage:\n");
                    foreach (var item in filteredVacuums)
                    {
                        if (item.Voltage == voltage)
                        {
                            Console.WriteLine(item.ToString());
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("RoomWhere the microwave will be installed: K (kitchen) or W (work site):");
                    string roomType = Console.ReadLine();

                    var filteredMicrowaves = Appliances.OfType<Microwave>().ToList();

                    Console.WriteLine($"Matching Microwaves with {roomType} RoomType:\n");
                    foreach (var item in filteredMicrowaves)
                    {
                        if (item.RoomType.ToLower() == roomType.ToLower())
                        {
                            Console.WriteLine(item.ToString());
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                    string rating = Console.ReadLine();

                    var filteredDishwashers = Appliances.OfType<Dishwasher>().ToList();

                    Console.WriteLine($"Matching Dishwashers with {rating} rating:\n");
                    foreach (var item in filteredDishwashers)
                    {
                        if (item.SoundRating.ToLower() == rating.ToLower())
                        {
                            Console.WriteLine(item.ToString());
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Error: Invalid Input");
                    break;
            }
        }
    }
}
