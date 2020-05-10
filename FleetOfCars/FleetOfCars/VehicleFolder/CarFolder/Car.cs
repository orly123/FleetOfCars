using FleetOfCars.DriverFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetOfCars.VehicleFolder.CarFolder
{
    abstract class Car : Vehicle
    {
        private int speed;
        private int amountOfDrivers = 2;
        private Driver secondDriver;
        protected Car(int id, int speed) : base(id)
        {
            this.Speed = speed;
        }

        public int Speed { get => speed; set => speed = value; }
        internal Driver SecondDriver { get => secondDriver; set => secondDriver = value; }

        public override string GetDrivers()
        {
            return base.GetDrivers() + this.SecondDriver.ToString();
        }
    }
}
