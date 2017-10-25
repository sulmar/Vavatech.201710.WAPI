using System;

namespace Vavatech.WAPI.Models
{
    public class Car : Vehicle
    {
        public decimal Capacity { get; set; }
    }

    public class Bike : Vehicle
    {

    }

    public abstract class Vehicle : Base
    {
        public DateTime ProductionDate { get; set; }

        public string Number { get; set; }

        public bool IsDeleted { get; set; }
    }
}
