using aspPopravni.Application.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Implementation
{
    public class UserImplementation : IUserUseCase
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<int> AllowedUseCases { get; set; }
    }
    public class UnauthorizedUser : IUserUseCase
    {
        public int Id => 0;
        public string Email => "/";
        public IEnumerable<int> AllowedUseCases { get; set; } = new List<int> { 1, 4 };
    }
}
