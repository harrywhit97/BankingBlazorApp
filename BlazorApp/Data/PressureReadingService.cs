using Domain.Models;
using PressureCore.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Repositories;
using Repository.Interfaces;
using Repository;

namespace BlazorApp.Data
{
    public class PressureReadingService
    {
        IRepository<PressureReading> Repository;
        const RepositoryType repositoryType = RepositoryType.SQLDataBase;
        

        public PressureReadingService()
        {
            Repository = RepositoryFactory.GetNewRepository<PressureReading>(repositoryType);
        }

        public void AddReading()
        {
            Repository.Add(GetPressureReadingAsync(1).Result[0]);
        }

        public void ClearReadings()
        {
            Repository.Clear();
        }

        public IList<PressureReading> GetReadings()
        {
            return Repository.GetAll();
        }

        public Task<PressureReading[]> GetPressureReadingAsync(int num)
        {
            var rng = new Random();
            var calculator = GetCalculator();
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

        IList<PressureReading> GeneratePressureReadings(int numVals)
        {
            var calc = GetCalculator();
            var rng = new Random();

            var readings = new List<PressureReading>();

            for (int i = 0; i < numVals; i++)
            {
                var rawValue = rng.Next(100, 255);
                readings.Add(GeneratePressureReading(rawValue, calc));
            }

            return readings;
        }

        PressureReading GeneratePressureReading(int rawValue, PressureCalculator calculator)
        {
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

    public class PressureReadingSingleton
    {
        public static PressureReadingService Service;

        public static PressureReadingService GetService()
        {
            if (Service is null)
                Service = new PressureReadingService();

            return Service;
        }
    }
}
