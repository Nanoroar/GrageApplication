﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrageApplication
{
    internal class Bus: Vehicle
    {
        public Bus(string regnr, int parkingNumber, string color, VehicleTypes Type, int numofpassengers, int numofwheels, bool withcabriolet) :
            base(regnr, parkingNumber, color, Type, numofpassengers, numofwheels, withcabriolet)
        {

        }
        //public override string ToString()
        //{
        //    return $"{Type.ToString()} {regNr} {color} parking number {parkingNumber}";
        //}
    }
}
