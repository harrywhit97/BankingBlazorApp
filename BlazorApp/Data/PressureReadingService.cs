using Domain.Models;
using PressureCore.Concrete;
using System;
using System.Collections.Generic;
using Domain.Controllers;

namespace BlazorApp.Data
{
    public class PressureReadingService
    {
        //TODO move these in to app config
        readonly PressureReadingController Controller;        

        public PressureReadingService(PressureReadingController controller)
        {
            Controller = controller;
        }

        public void AddReading()
        {
            AddReading(GeneratePressureReadings(1)[0]);
        }

        public void AddReading(PressureReading reading)
        {
            Controller.Add(reading);
        }

        public void RemoveReading(PressureReading reading)
        {
            Controller.Remove(reading);
        }

        public void ClearReadings()
        {
            Controller.Clear();
        }

        public IList<PressureReading> GetReadings()
        {
            return Controller.GetAll();
        }

        IList<PressureReading> GeneratePressureReadings(int numVals)
        {
            var calc = GetCalculator();
            var rng = new Random();

            var readings = new List<PressureReading>();

            for (int i = 0; i < numVals; i++)
            {
                var rawValue = rng.Next(100, 255);
                readings.Add(CalculatePressureReading(rawValue, calc));
            }

            return readings;
        }

        public PressureReading CalculatePressureReading(BasePressureReading basePressureReading, PressureCalculator calculator = null)
        {
            if (calculator is null)
                calculator = GetCalculator();

            return new PressureReading()
            {
                RawValue = basePressureReading.RawValue,
                TimeStamp = basePressureReading.TimeStamp,
                BAR = calculator.CalculateBAR(basePressureReading.RawValue),
                PSI = calculator.CalculatePSI(basePressureReading.RawValue)
            };
        }

        public BasePressureReading CreateBasePressureReading(int raw)
        {
            return new BasePressureReading()
            {
                RawValue = raw,
                TimeStamp = DateTimeOffset.UtcNow
            };
        }

        public PressureReading CalculatePressureReading(int rawValue, PressureCalculator calculator = null)
        {
            if (calculator is null)
                calculator = GetCalculator();

            return new PressureReading()
            {
                RawValue = rawValue,
                BAR = calculator.CalculateBAR(rawValue),
                PSI = calculator.CalculatePSI(rawValue),
                TimeStamp = DateTimeOffset.UtcNow
            };
        }

        PressureCalculator GetCalculator()
        {
            return new PressureCalculator()
            {
                BARMax = 16,
                ArduinoMaxVoltage = 54,
                MaxVoltage = 4.24M,
                ArduinoTotalIntervals = 1024
            };
        }
    }
}
