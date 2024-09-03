using aspPopravni.Implementation.UseCases.Queries;
using aspPopravni.Implementation;
using Microsoft.AspNetCore.Mvc;
using aspPopravni.Application.DTO;
using aspPopravni.Application.Queries;
using aspPopravni.Application.Commands;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace aspPopravni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        // GET: api/<LoansController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchUserLoansDTO search,
                                [FromServices] IGetUserLoans query,
                                 [FromServices] UseCaseHandler handler)
        {
            return Ok(handler.HandleQuery(query, search));
        }

        // POST api/<LoanssController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateLoanDTO dto,
                                  [FromServices] ICreateLoan command,
                                  [FromServices] UseCaseHandler handler
)
        {
            handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // GET: api/<LoansController>
        [HttpDelete]
        public void Delete([FromQuery] DeleteLoanDTO dto,
                                [FromServices] IDeleteLoan command,
                                 [FromServices] UseCaseHandler handler)
        {
            handler.HandleCommand(command, dto);
        }
    }
}
