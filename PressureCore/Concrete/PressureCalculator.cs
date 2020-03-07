using System;

namespace PressureCore.Concrete
{
    public class PressureCalculator
    {
        /// <summary>
        /// Voltage on arduino at 10V/16bar
        /// </summary>
        public decimal MaxVoltage { get; set; }
        public int ArduinoMaxVoltage { get; set; }
        public decimal BARMax { get; set; }
        public int ArduinoTotalIntervals { get; set; }

        const decimal BARtoPSIRatio = 14.504M;

        public virtual decimal CalculatePSI(decimal RawReading)
        {            
            return Calculate(RawReading, BARtoPSI(BARMax));
        }

        public virtual decimal CalculateBAR(decimal RawReading)
        {
            return Calculate(RawReading, BARMax);
        }

        decimal Calculate(decimal RawReading, decimal maxP)
        {
            return Math.Round(((RawReading / ArduinoTotalIntervals) * (maxP / MaxVoltage)) * ArduinoMaxVoltage, 1, MidpointRounding.AwayFromZero);
        }

        decimal BARtoPSI(decimal BAR)
        {
            return BAR * BARtoPSIRatio;
        }
    }
}
