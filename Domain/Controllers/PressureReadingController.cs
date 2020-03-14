using Domain.Abstract;
using Domain.Models;

namespace Domain.Controllers
{
    public class PressureReadingController : GenericController<PressureReading>
    {
        public PressureReadingController(EFDbContext context)
            : base(context)
        {
        }
    }
}
