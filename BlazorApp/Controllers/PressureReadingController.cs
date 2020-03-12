using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository.Repositories;
using System.Collections.Generic;

namespace Domain.Controllers
{
    [ApiController]
    public class PressureReadingController : GenericController<PressureReading>
    {
        public PressureReadingController(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
