using Domain.Models;
using System;
using System.Collections.Generic;

namespace PressureCore.Concrete
{
    public static class RawDataProcessor
    {
        public static List<PressureReading> ParseRawDataToPressureReadings(string rawData, PressureCalculator calculator, DateTimeOffset timestamp)
        {
            var data = RawDataToDictionary(rawData);
            return SerialDataToPressureReading(data, calculator, timestamp);
        }

        static Dictionary<string, decimal> RawDataToDictionary(string rawData)
        {
            var dataSeparated = rawData.Split(',');
            var data = new Dictionary<string, decimal>();

            for (int i = 0; i < dataSeparated.Length; i += 2)
            {
                var readingString = dataSeparated[i + 1];

                if (!decimal.TryParse(readingString, out var reading))
                    throw new Exception($"Reading {readingString} is not an integer");

                data.Add(dataSeparated[i], reading);
            }
            return data;
        }

        static List<PressureReading> SerialDataToPressureReading(Dictionary<string, decimal> data, PressureCalculator calculator, DateTimeOffset timestamp)
        {
            var readings = new List<PressureReading>();

            foreach (var key in data.Keys)
            {
                var rawValue = data[key];
                var reading = new PressureReading
                {
                    SensorName = key,
                    RawValue = rawValue,
                    TimeStamp = timestamp,
                    PSI = calculator.CalculatePSI(rawValue),
                    BAR = calculator.CalculateBAR(rawValue)
                };
                readings.Add(reading);
            }
            return readings;
        }
    }
}
