using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetOfCars.DriverFolder;
namespace FleetOfCars.VehicleFolder.CarFolder
{
    sealed class SportCar : Car
    {
        private int maxSpeed = 200;

        public SportCar(int id, string brand, string color, int speed) : base(id, speed)
        {
        }
        public override string GetDrivers()
        {
            return base.GetDrivers();
        }
        public override string GetVehicleType()
        {
            return base.GetVehicleType() + "Sport Car";
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