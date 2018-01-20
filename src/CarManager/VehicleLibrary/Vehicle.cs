using System;

namespace VehicleLibrary
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string GetFullCar()
        {
            return $"{Year} {Make} {Model}";
        }
    }
}
