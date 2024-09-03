using aspPopravni.Application.DTO;
using aspPopravni.Application.Queries;
using aspPopravni.DataAccess;
using aspPopravni.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace aspPopravni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private popravniContext _context;

        public AvailabilityController(popravniContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAvailable([FromQuery] SearchBookAvailabilityDTO search,
                                [FromServices] IBookAvailabilityCheck query,
                                 [FromServices] UseCaseHandler handler)
        {
            return Ok(handler.HandleQuery(query, search));
        }
    }
}
