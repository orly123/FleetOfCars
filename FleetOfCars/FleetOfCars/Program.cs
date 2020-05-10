using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FleetOfCars.DriverFolder;
using FleetOfCars.VehicleFolder;
using FleetOfCars.VehicleFolder.BicycleFolder;
using FleetOfCars.VehicleFolder.CarFolder;

namespace FleetOfCars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            List<Driver> drivers = new List<Driver>();
            Driver erez = new Driver(200, "Erez");
            Driver ron = new Driver(130, "Ron");
            Driver ido = new Driver(220, "Ido");
            SportCar mazdaCar = new SportCar(0, "Toyota", "Red", 150);
            CrossOver suzukiCrossOver = new CrossOver(1, "suzuki", "black", 100);
            Bicycle bmx = new Bicycle(2, "BMX", "white");

            mazdaCar.FirstDriver = erez;
            mazdaCar.SecondDriver = ron;
            bmx.FirstDriver = ido;
            drivers.Add(erez);
            drivers.Add(ron);
            drivers.Add(ido);
            vehicles.Add(mazdaCar);
            vehicles.Add(suzukiCrossOver);
            vehicles.Add(bmx);

            string quit;
            string assignVehicle;
            string assignDriver;
            string position;
            string id;
            string carType;
            string input = "-1";



            while (input != "8")
            {
                Console.WriteLine(
                "Please input your option -> \n\n" +
                "1- Add new vehicle \n" +
                "2- Show vehicle list \n" +
                "3- Delete a vehicle\n" +
                "4- Add new driver \n" +
                "5- show driver list \n" +
                "6- Delete a driver\n" +
                "7- Assign a driver\n" +
                "8- Exit\n"
                );
                input = (Console.ReadLine());
                if (!IsNumeric(input)) InvalidKey();
                else
                {
                    switch (input)
                    {
                        case "1":
                            Console.Write(
                            "Please choose your option-> \n" +
                            "1- Bicycle \n" +
                            "2- Sport Car \n" +
                            "3- CrossOver\n"
                            );
                            carType = (Console.ReadLine());
                            if (!IsNumeric(carType) && carType != "1" && carType != "2" && carType != "3") InvalidKey();
                            else
                            {
                                Vehicle temp = AddVehicleHandler(vehicles[vehicles.Count - 1].Id + 1, carType);
                                if (temp != null) vehicles.Add(temp); 
                            }
                            PressAnyKey();
                            break;

                        case "2":
                            foreach (Vehicle element in vehicles)
                            {
                                Console.WriteLine(element.ToString());
                            }
                            PressAnyKey();
                            break;
                        case "3":
                            bool flag = true;
                            foreach (Vehicle element in vehicles)
                            {
                                Console.WriteLine(element.ToString());
                            }
                            Console.Write("Choose ID to remove ->");
                            id = Console.ReadLine();
                            if (!IsNumeric(id))
                            {
                                InvalidKey();
                                PressAnyKey();
                                break;
                            }
                            else
                            {
                                flag = false;
                                foreach (Vehicle element in vehicles)
                                {
                                    if (element.Id == int.Parse(id))
                                    {
                                        vehicles.Remove(element);
                                        flag = true;
                                        break;
                                    }
                                }
                                if (flag) Console.WriteLine("Vehicle removed successfully!");
                                else Console.WriteLine("ID not found. Nothing removed.");
                            }
                            PressAnyKey();
                            break;
                        case "4":
                            drivers.Add(AddDriverHandler());
                            PressAnyKey();
                            break;
                        case "5":
                            foreach (Driver element in drivers)
                            {
                                Console.WriteLine(element.ToString());
                            }
                            PressAnyKey();
                            break;
                        case "6":
                            flag = true;
                            foreach (Driver element in drivers)
                            {
                                Console.WriteLine(element.ToString());
                            }
                            Console.Write("Choose ID to remove ->");
                            id = Console.ReadLine();
                            if (!IsNumeric(id))
                            {
                                InvalidKey();
                                break;
                            }
                            else
                            {
                                flag = false;
                                foreach (Driver element in drivers)
                                {
                                    if (element.Id == int.Parse(id))
                                    {
                                        drivers.Remove(element);
                                        flag = true;
                                        break;
                                    }
                                }
                                if (flag) Console.WriteLine("Driver removed successfully!");
                                else Console.WriteLine("ID not found. Nothing removed.");
                            }
                            PressAnyKey();
                            break;
                        case "7":
                            foreach (Vehicle element in vehicles)
                            {
                                Console.WriteLine(element.ToString());
                            }
                            Console.Write("Choose Vehicle ID to assign a driver to ->");
                            assignVehicle = Console.ReadLine();
                            flag = false;
                            foreach (Vehicle element in vehicles)
                            {
                                if (element.Id == int.Parse(assignVehicle))
                                {
                                    flag = true;
                                    Vehicle vehicle = element;
                                    break;
                                }
                            }
                            if (!flag)
                            {
                                Console.WriteLine("ID not found, please try again.");
                                break;
                            }
                            else
                            {
                                foreach (Driver element in drivers)
                                {
                                    Console.WriteLine(element.ToString());
                                }
                                Console.Write("Choose Driver ID to assign to the selected vehicle ->");
                                assignDriver = Console.ReadLine();

                                foreach (Driver element in drivers)
                                {
                                    if (element.Id == int.Parse(assignDriver))
                                    {
                                        flag = true;
                                        Driver driver = element;
                                        break;
                                    }
                                }
                                if (!flag)
                                {
                                    Console.WriteLine("ID not found, please try again.");
                                    break;
                                }
                                else
                                {

                                    foreach (Vehicle vehicle in vehicles)
                                    {
                                        if (vehicle.Id == int.Parse(assignVehicle))
                                        {
                                            foreach (Driver driver in drivers)
                                            {
                                                if (driver.Id == int.Parse(assignDriver))
                                                {
                                                    if (vehicle.AmoutOfDrivers == 1)
                                                    {
                                                        vehicle.FirstDriver = driver;
                                                    }
                                                    else
                                                    {
                                                        Car carVehicle = (Car)vehicle;
                                                        Console.Write("Which Driver position do you want to assign to? (1/2) ->");
                                                        position = Console.ReadLine();
                                                        if (!IsNumeric(position))
                                                        {
                                                            InvalidKey();
                                                            flag = false;
                                                            break;
                                                        }
                                                        else switch (position)
                                                            {
                                                                case "1":
                                                                    carVehicle.FirstDriver = driver;
                                                                    break;
                                                                case "2":
                                                                    carVehicle.SecondDriver = driver;
                                                                    break;
                                                                default: break;
                                                            }
                                                    }
                                                    Console.WriteLine("Driver assigned successfully!");
                                                    PressAnyKey();
                                                    break;
                                                }
                                            }
                                        }
                                        if (!flag) break;
                                    }
                                }
                            }
                            PressAnyKey();
                            break;
                        case "8":
                            Console.Write("Are you sure you want to quit? (y/n) ->");
                            quit = Console.ReadLine();
                            if (quit == "y") break;
                            else if (quit == "n")
                            {
                                input = "-1";
                                break;
                            }
                            InvalidKey();
                            PressAnyKey();
                            break;
                        default: break;
                    }
                }
                Console.Clear();
            }
        }
        
        public static bool IsNumeric(string value)
        {
            bool check = value.All(char.IsNumber);
            if (check) return true;
            else return false;
        }

        public static void InvalidKey()
        {
            Console.WriteLine("Invalid key! Try again.");
        }

        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }


        public static Vehicle AddVehicleHandler(int id, string carType)
        {
            string brand;
            string color;
            string speed;
            switch (carType)
            {
                case "1":
                    Console.Write("Enter Brand ->");
                    brand = Console.ReadLine();
                    Console.Write("Enter Color ->");
                    color = Console.ReadLine();
                    return new Bicycle(id, brand, color);
                case "2":
                    Console.Write("Enter Brand ->");
                    brand = Console.ReadLine();
                    Console.Write("Enter Color ->");
                    color = Console.ReadLine();
                    Console.Write("Enter Speed ->");
                    speed = (Console.ReadLine());
                    if (!IsNumeric(speed))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Vehicle added successfully!");
                        return new SportCar(id, brand, color, int.Parse(speed));
                    }
                case "3":
                    Console.Write("Enter Brand ->");
                    brand = Console.ReadLine();
                    Console.Write("Enter Color ->");
                    color = Console.ReadLine();
                    Console.Write("Enter Speed ->");
                    speed = (Console.ReadLine());
                    if (!IsNumeric(speed))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Vehicle added successfully!");
                        return new CrossOver(id, brand, color, int.Parse(speed));
                    }
                default: break;
            }
            InvalidKey();
            return null;
        }
        public static Driver AddDriverHandler()
        {
            string id;
            string name;
            Console.Write("Enter ID ->");
            id = Console.ReadLine();
            if (!IsNumeric(id))
            {
                InvalidKey();
                return null;
            }
            Console.Write("Enter Name ->");
            name = Console.ReadLine();
            Console.WriteLine("Driver added successfully!");
            return new Driver(int.Parse(id), name);
        }

    }
}

        
    

