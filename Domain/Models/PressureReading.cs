namespace Domain.Models
{
    public class PressureReading : BasePressureReading
    {
        public decimal PSI { get; set; }
        public decimal BAR { get; set; }
        public string SensorName { get; set; }        
    }
}
