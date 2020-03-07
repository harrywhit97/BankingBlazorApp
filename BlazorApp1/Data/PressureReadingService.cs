using Domain.Models;
using PressureCore.Concrete;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class PressureReadingService
    {

        public Task<PressureReading[]> GetPressureReadingAsync()
        {
            var rng = new Random();

            var calculator = new PressureCalculator()
            {
                BARMax = 16,
                ArduinoMaxVoltage = 54,
                MaxVoltage = 4.24M,
                ArduinoTotalIntervals = 1024
            };



            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new PressureReading
            {
                RawValue = rng.Next(100, 255),
                BAR = calculator.CalculateBAR(rng.Next(100, 255)),
                PSI = calculator.CalculatePSI(rng.Next(100, 255)),
                TimeStamp = new DateTimeOffset()
            }).ToArray());
        }
    }
}
