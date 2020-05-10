
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetOfCars.DriverFolder;

namespace FleetOfCars.VehicleFolder.BicycleFolder
{
    sealed class Bicycle : Vehicle
    {
        public Bicycle(int id, string brand, string color) : base(id, brand, color)
        {
        }

        public override string GetDrivers()
        {
            return base.GetDrivers();
        }
        public override string GetVehicleType()
        {
            return base.GetVehicleType() + " Bicycle";
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
