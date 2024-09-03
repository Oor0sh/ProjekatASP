using aspPopravni.API.JWT;
using aspPopravni.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace aspPopravni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtManager _manager;

        public AuthController(JwtManager manager)
        {
            _manager = manager;
        }

        // POST api/<AuthController>
        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest request,
                         [FromServices] popravniContext context)
        {
            string token = _manager.MakeToken(request.Email, request.Password);

            return Ok(new { token });
        }

        [HttpDelete]
        [Authorize]
        public IActionResult InvalidateToken([FromServices] ITokenStorage storage)
        {
            var header = HttpContext.Request.Headers["Authorization"];

            var token = header.ToString().Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            string jti = tokenObj.Claims.FirstOrDefault(x => x.Type == "jti").Value;

            storage.InvalidateToken(jti);

            return NoContent();
        }
    }
}
