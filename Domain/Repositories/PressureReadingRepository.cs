using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public class PressureReadingRepository
    {
        IList<PressureReading> Repository;

        public PressureReadingRepository()
        {
            Repository = new List<PressureReading>();
        }

        public void Add(PressureReading reading)
        {
            Repository.Add(reading);
        }

        public IList<PressureReading> GetPressureReadings()
        {
            return Repository;
        }
    }
}
