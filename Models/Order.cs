using System;

namespace Cars.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public int CodeTaxi { get; set; }
        public string Address { get; set; }
        public DateTime OrderTime { get; set; }
        public double Distance { get; set; }
        public double Fare { get; set; }
    }
}