using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace Domain.Controllers
{
    [ApiController]
    public class PressureReadingController : GenericController<PressureReading>
    {
        public PressureReadingController(IRepository<PressureReading> repository) 
            : base(repository)
        {
        }
    }
}
