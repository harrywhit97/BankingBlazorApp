using System;
using Domain.Abstract;

namespace Domain.Models
{
    public class BasePressureReading : Entity
    {
        public decimal RawValue { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
