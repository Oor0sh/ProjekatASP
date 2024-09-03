using aspPopravni.Application.Queries;
using aspPopravni.Implementation.UseCases.Commands;
using aspPopravni.Implementation;
using Microsoft.AspNetCore.Mvc;
using aspPopravni.Application.DTO;
using aspPopravni.Application.Commands;

namespace aspPopravni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchUserDTO search,
                                [FromServices] IGetUsers query,
                                 [FromServices] UseCaseHandler handler)
        {
            return Ok(handler.HandleQuery(query, search));
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDTO dto,
                                  [FromServices] ICreateUser command,
                                  [FromServices] UseCaseHandler handler
)
        {
            handler.HandleCommand(command, dto);
            return StatusCode(201);
        }
    }
}
