using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrageApplication
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public Garage(int Maxnumofparks)
        {
            MaxnumofParks = Maxnumofparks;
            if (Maxnumofparks < 0 || MaxnumofParks > 10000) MaxnumofParks = 1000;
        }
           
        private List<T> vehicles = new List<T>();

        public List<T> Vehicles
        {
            get { return vehicles = new List<T>(); }
            
        }

        public int MaxnumofParks;

        public IEnumerator<T> GetEnumerator() => vehicles.GetEnumerator();  
       

        IEnumerator IEnumerable.GetEnumerator() => vehicles.GetEnumerator();

        // method to add vehicles 
        public void AddVehicle(T Vehicle)
        {
            vehicles.Add(Vehicle);  
        }

        public void ListVehicles( Garage<T> g)
        {
            if(vehicles.Count >= 0)
            {
                foreach (T vehicle in vehicles)
                {
                    Console.WriteLine(vehicle);
                }
            }
            else Console.WriteLine("This list is empty");
        }

        public void ListTypeOfVehicles(Garage<T> g)
        {
            int numofCars = 0;
            int numofMC = 0;
            int numofMoped = 0;
            int numofBus = 0;
            int numofTruck = 0;
            foreach(Vehicle vehicle in g)
            {
                if(vehicle is Car)
                {
                    numofCars++;
                }
               

                else if (vehicle is MC)
                {
                    numofMC++;
                }
              
                else if (vehicle is Moped)
                {
                    numofMoped++;
                }
               

                else if (vehicle is Bus)
                {
                    numofBus++;
                }
               

                else if (vehicle is Truck)
                {
                    numofTruck++;
                }
               
            }
            Console.WriteLine($"There are {numofCars} Cars in this Garage");
            Console.WriteLine("======================================");
            Console.WriteLine($"There are {numofMC} MC in this Garage");
            Console.WriteLine("======================================");
            Console.WriteLine($"There are {numofMoped} Moped in this Garage");
            Console.WriteLine("======================================");
            Console.WriteLine($"There are {numofBus} Bus in this Garage");
            Console.WriteLine("======================================");

            Console.WriteLine($"There are {numofTruck} Truck in this Garage");
            Console.WriteLine("======================================");
        }

        //Method remover vehicle 
        public void RemoveVehicle(Garage<T> Vehicles, string regnr) 
        {
            bool exist = false;
            foreach (var vehicle in Vehicles)
            {
                if (vehicle.regNr == regnr.ToUpper())
                {
                    
                    exist = true;
                }
            }
            if (!exist) Console.WriteLine("Nu suck Vehicle Registed");

            vehicles.RemoveAll(v => v.regNr == regnr.ToUpper());

        }

        public void SearchByRegNr(Garage<T> Vehicles, string regnr)
        {
            bool exist = false;
            foreach(var vehicle in Vehicles)
            {
                if (vehicle.regNr == regnr.ToUpper())
                {
                    Console.WriteLine($"{vehicle.GetType().Name} {vehicle.regNr} parking number: {vehicle.parkingNumber}");
                    exist = true;
                }
            }
            if (!exist) Console.WriteLine("Nu suck Vehicle Registed");
         
        }

        public void SearchByColor(Garage<T> Vehicles, string color)
        {
            bool exists = false;    
            foreach(var vehicle in Vehicles)
            {
                if(vehicle.color == color.ToUpper())
                {
                    exists = true;
                    Console.WriteLine($"{vehicle.color.ToUpper()} {vehicle.GetType().Name} {vehicle.regNr} parking number: {vehicle.parkingNumber}");
                }
            }
            if(!exists) Console.WriteLine("No Vehicles have this Color in this Garage");
        }

        public void SearchbyType(Garage<T> g, string typeofVehicle)
        {
            typeofVehicle = typeofVehicle.ToUpper();
            if (typeofVehicle == "CAR")
            {
                foreach (Vehicle vehicle in g)
                {
                    if (vehicle.Type == VehicleTypes.Car) Console.WriteLine(vehicle);                   
                }
                
            }

            else if (typeofVehicle == "BUS")
            {
                foreach (Vehicle vehicle in g)
                {
                    if (vehicle.Type == VehicleTypes.Bus) Console.WriteLine(vehicle);
                }               
            }

            else if (typeofVehicle == "MC")
            {
                foreach (Vehicle vehicle in g)
                {
                    if (vehicle.Type == VehicleTypes.MC) Console.WriteLine(vehicle);                   
                }              
            }

            else if (typeofVehicle == "MOPED")
            {
                foreach (Vehicle vehicle in g)
                {
                    if (vehicle.Type == VehicleTypes.Moped) Console.WriteLine(vehicle);                   
                }                
            }

            else if (typeofVehicle == "TRUCK")
            {
                foreach (Vehicle vehicle in g)
                {
                    if (vehicle.Type == VehicleTypes.Truck) Console.WriteLine(vehicle);                  
                }               
            }
            else Console.WriteLine("There is no such type of vehicles in this garage!");

        }

    }
}
