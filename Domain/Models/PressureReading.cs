using System;

namespace Domain.Models
{
    public class PressureReading
    {
        public long Id { get; set; }
        public decimal RawValue { get; set; }
        public decimal PSI { get; set; }
        public decimal BAR { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string SensorName { get; set; }        
    }
}
