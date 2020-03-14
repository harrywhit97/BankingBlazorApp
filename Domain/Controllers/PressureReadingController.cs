using Domain.Abstract;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Controllers
{
    public class PressureReadingController : GenericController<PressureReading>
    {
        public PressureReadingController(DbContext context)
            : base(context)
        {
        }
    }
}
