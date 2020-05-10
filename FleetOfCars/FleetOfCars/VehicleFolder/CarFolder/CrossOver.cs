
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetOfCars.DriverFolder;

namespace FleetOfCars.VehicleFolder.CarFolder
{
    sealed class CrossOver : Car
    {
        public CrossOver(int id, string brand, string color, int speed) : base(id, speed)
        {
        }
        public override string GetDrivers()
        {
            return base.GetDrivers();
        }
        public override string GetVehicleType()
        {
            return base.GetVehicleType() + "CrossOver";
        }
        public override string ToString()
        {
            if (this.SecondDriver is Driver)
            {
                return base.ToString() + "\nDriver: " + this.SecondDriver.ToString();
            }
            else return base.ToString();
        }
    }
}