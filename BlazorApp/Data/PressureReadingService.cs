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

            var num = 5;

            var rawVals = new int[num];

            for (int i = 0; i < num; i++)
                rawVals[i] = rng.Next(100, 255);                           

            return Task.FromResult(rawVals.Select(rawVal => new PressureReading
            {
                RawValue = rawVal,
                BAR = calculator.CalculateBAR(rawVal),
                PSI = calculator.CalculatePSI(rawVal),
                TimeStamp = DateTimeOffset.UtcNow
            }).ToArray());
        }
    }
}
