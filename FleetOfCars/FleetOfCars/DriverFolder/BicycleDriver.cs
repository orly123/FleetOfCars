using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetOfCars.DriverFolder
{
    sealed class BicycleDriver : Driver
    {
        private bool helmet;
        public BicycleDriver(int id, string name, bool helmet) : base(id, name)
        {
            this.helmet = helmet;
        }
    }
}
