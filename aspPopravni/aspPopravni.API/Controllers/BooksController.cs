using aspPopravni.Application.Commands;
using aspPopravni.Application.DTO;
using aspPopravni.Application.Queries;
using aspPopravni.DataAccess;
using aspPopravni.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace aspPopravni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private popravniContext _context;

        public BooksController(popravniContext context)
        {
            _context = context;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchBookDTO search,
                                [FromServices] IGetBooks query,
                                 [FromServices] UseCaseHandler handler)
        {
            return Ok(handler.HandleQuery(query, search));
        }

        // POST api/<BooksController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateBookDTO dto,
                                  [FromServices] ICreateBook command,
                                  [FromServices] UseCaseHandler handler
)
        {
            handler.HandleCommand(command, dto);
            return StatusCode(201);
        }


        // PUT api/<BooksController>
        [HttpPut]
        public void Put([FromBody] UpdateBookDTO dto, [FromServices] IUpdateBook command, [FromServices] UseCaseHandler handler)
        {
            handler.HandleCommand(command, dto);
        }
    }
}
