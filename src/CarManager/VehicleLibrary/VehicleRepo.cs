using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleLibrary
{
    public class VehicleRepo
    {
        private static List<Vehicle> _vehicles = new List<Vehicle>();
        private static int nextId = 0;

        public List<Vehicle> ListAll()
        {
            return _vehicles;
        }

        public Vehicle GetById(int id)
        {
            return _vehicles.Find(v => v.Id == id);
        }

        public void AddVehicle(Vehicle newVehicle)
        {
            newVehicle.Id = nextId++;
            _vehicles.Add(newVehicle);
        }
    }
}
