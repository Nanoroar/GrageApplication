using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrageApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            Garage<Vehicle> garage = new Garage<Vehicle>(1000);

            // Adding some Vehicles for test
            garage.AddVehicle(new Car("FTJ457", 1, "Silver".ToUpper(), VehicleTypes.Car, 5, 4, false));
            garage.AddVehicle(new MC("FSJ557", 2, "Yellow".ToUpper(), VehicleTypes.MC, 2, 2, false));
            garage.AddVehicle(new Car("BTT457", 3, "Red".ToUpper(), VehicleTypes.Moped, 2, 2, false));
            garage.AddVehicle(new Car("ATJ457", 4, "Black".ToUpper(), VehicleTypes.Truck, 2, 10, false));
            garage.AddVehicle(new Car("VTJ457", 5, "White".ToUpper(), VehicleTypes.Bus, 50, 8, false));
            garage.AddVehicle(new Car("STT457", 6, "Red".ToUpper(), VehicleTypes.Car, 2, 4, true));

            int searchFilter = 0;
            do
            {
               searchFilter = Vehicle.searchFilter();
            

            if(searchFilter == 1)
            {
                Console.WriteLine("Enter the Registration number of the Vehicle");
                garage.SearchByRegNr(garage, Console.ReadLine());
            }
            else if (searchFilter == 2)
            {
                Console.WriteLine("Enter the Color of the Vehicle");
                garage.SearchByColor(garage, Console.ReadLine());   
            }
            else if(searchFilter == 3)
            {
                Console.WriteLine("Enter the type of Vehicle that you are searching for");
                garage.SearchbyType(garage, Console.ReadLine());
            }
            else if (searchFilter == 4)
            {
                garage.ListVehicles(garage);
            }

            else if(searchFilter == 5)
            {
                string answer = "";
                do
                {

                    string regnr = "";
                    do
                    {
                        Console.WriteLine("Please enter a valid Registration number for the Vehicle like \"ABC123\"");
                        regnr = Vehicle.validRegNr(Console.ReadLine());
                    } while (regnr == null);

                    Console.WriteLine("Enter Parkings number ");
                    int parkingsNUmber = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter color");
                    string color = Console.ReadLine().ToUpper();
                    if (string.IsNullOrEmpty(color)) color = "White";

                    Console.WriteLine("Enter number of vehicletype, 1 = Car, 2 = MC, 3 = Moped, 4 = Bus, 5 = Truck");
                    VehicleTypes typeofVehicle = Vehicle.GetType(Console.ReadLine());

                    Console.WriteLine("Enter number of passenegers");
                    int numofpassengers = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter number of Wheels");
                    int numofwheels = int.Parse(Console.ReadLine());

                    Console.WriteLine("Vehicle has Cabriolet? Yes/No");
                    bool hascabriolet = Vehicle.hasCabriolet(Console.ReadLine());

                    if (typeofVehicle == VehicleTypes.Car)
                    {
                        Vehicle myVehicle = new Car(regnr, parkingsNUmber, color, typeofVehicle, numofpassengers, numofwheels, hascabriolet);
                        garage.AddVehicle(myVehicle);
                    }

                    if (typeofVehicle == VehicleTypes.MC)
                    {
                        Vehicle myVehicle = new MC(regnr, parkingsNUmber, color, typeofVehicle, numofpassengers, numofwheels, hascabriolet);
                        garage.AddVehicle(myVehicle);
                    }
                    if (typeofVehicle == VehicleTypes.Moped)
                    {
                        Vehicle myVehicle = new Moped(regnr, parkingsNUmber, color, typeofVehicle, numofpassengers, numofwheels, hascabriolet);
                        garage.AddVehicle(myVehicle);
                    }
                    if (typeofVehicle == VehicleTypes.Bus)
                    {
                        Vehicle myVehicle = new Bus(regnr, parkingsNUmber, color, typeofVehicle, numofpassengers, numofwheels, hascabriolet);
                        garage.AddVehicle(myVehicle);
                    }
                    if (typeofVehicle == VehicleTypes.Truck)
                    {
                        Vehicle myVehicle = new Truck(regnr, parkingsNUmber, color, typeofVehicle, numofpassengers, numofwheels, hascabriolet);
                        garage.AddVehicle(myVehicle);
                    }
                    Console.WriteLine("Do you want to add another Vehicle?");
                    answer = Console.ReadLine();
                } while (answer == "yes");


            }


            else if(searchFilter == 6)
            {
                Console.WriteLine("Enter the registration number of the vehicle to delete");
                garage.RemoveVehicle(garage, Console.ReadLine());   
            }

            else if(searchFilter == 7)
            {
                garage.ListTypeOfVehicles(garage);
            }
                Console.WriteLine("Press enter to preform another task from the list");
                Console.ReadLine();              
                Console.Clear();
            } while (searchFilter != 0);

            
            Console.ReadKey();

             
        }
    }
}
