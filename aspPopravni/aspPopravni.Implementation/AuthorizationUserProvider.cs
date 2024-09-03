using aspPopravni.Application.UseCase;
using aspPopravni.DataAccess;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Implementation
{
    public class AuthorizationUserProvider : IUserUseCaseProvider
    {
        private string _authorizationHeader;
        private popravniContext _context;

        public AuthorizationUserProvider(string authorizationHeader, popravniContext context)
        {
            _authorizationHeader = authorizationHeader;
            _context = context;
        }
        public IUserUseCase getUser()
        {
            var data = _authorizationHeader.ToString().Split("Bearer ");
            if (data.Length < 2)
            {
                return new UnauthorizedUser();
            }
            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(data[1].ToString());

            var claims = tokenObj.Claims;

            var email = claims.First(x => x.Type == "Email").Value;
            var id = claims.First(x => x.Type == "Id").Value;
            var useCases = claims.First(x => x.Type == "UseCases").Value;

            List<int> useCaseIds = JsonConvert.DeserializeObject<List<int>>(useCases);

            return new UserImplementation
            {
                Id = int.Parse(id),
                AllowedUseCases = useCaseIds,
                Email = email
            };
        }
    }
}
