using Domain.Abstract;
using System;

namespace Domain.Models
{
    public class PressureReading : Entity
    {
        public decimal RawValue { get; set; }
        public decimal PSI { get; set; }
        public decimal BAR { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string SensorName { get; set; }        
    }
}
