using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrageApplication
{
    public class Vehicle
    {
        public string regNr { get; set; }
        public string color { get; set; } = "White";
        public VehicleTypes Type ;
        public int numOfPassangers ;

        public int parkingNumber;
        
        public int numOfWheels ;
        public bool withCabriolet  = false;

        public Vehicle(string regnr,int parkingNumber, string color, VehicleTypes Type, int numofpassengers , 
            int numofwheels , bool withcabriolet )
        {
            regNr = regnr;
            this.parkingNumber = parkingNumber;  
            this.color = color;
            this.Type = Type;
            numOfPassangers = numofpassengers;
            numOfWheels = numofwheels;
            withCabriolet = withcabriolet;
        }

        public static string validRegNr(string regnr)
        {
            regnr = regnr.Trim();
            if (regnr.Length == 6)
            {
                for (int i = 0; i < 3; i++) if (!char.IsLetter(regnr[i])) return null;
                for (int i = 3; i < 6; i++) if (!char.IsDigit(regnr[i])) return null;
                return regnr.ToUpper();
            }
            else return null;
        }

        public static VehicleTypes GetType(string strVType)
        {
            if (string.IsNullOrEmpty(strVType)) strVType = "1";
            int typenr = int.Parse(strVType);
            VehicleTypes type = (VehicleTypes)typenr;
             
            return type; 
        }

        
        public static bool hasCabriolet(string str)
        {
            switch (str)
            {
                case "Yes":
                case "yes":
                    return true;
                case "No":
                case "no":
                    return false;
                    default: return false;  
            }
        }

        public override string ToString()
        {
            return $"{Type}  {regNr}  parking number: {parkingNumber}  {color} Number of passengers:{numOfPassangers} " +
                $"Number of wheels:{numOfWheels} Vehicle has Cabriolet:{withCabriolet}";
        }


        public static int searchFilter()   // tested
        {
            string filter;
            Console.WriteLine("Select from search menue the type of search\n" +
               "0-Exit/Close Application\n"+
               "1-Search by Registeration number\n" +
               "2-Search by Color\n" +
               "3-Search by type\n" +
               "4-Show all Vehicles\n" +
               "5-Add a New Vehicle\n" +
               "6-Delete a Vehicle\n" +
               "7-List Vehicle by type");
            filter = Console.ReadLine();
            for (; ; )
            {
                bool isNumeric = int.TryParse(filter, out int n);
                if(isNumeric && n == 0) Environment.Exit(0);    
                else if (isNumeric && n >= 1 && n <= 7)
                {
                    return n;
                }
                else
                {
                    Console.WriteLine("choose from the menue and try again");
                    filter = Console.ReadLine();
                }
            }
        }

    }
}
