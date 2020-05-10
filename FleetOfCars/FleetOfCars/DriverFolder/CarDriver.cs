using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetOfCars.DriverFolder
{
    sealed class CarDriver : Driver
    {
        private int age;
        public CarDriver(int id, string name, int age) : base(id, name)
        {
            this.age = age;
        }
    }
}
