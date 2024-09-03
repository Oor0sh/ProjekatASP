using aspPopravni.Application.Commands;
using aspPopravni.Application.DTO;
using aspPopravni.DataAccess;
using aspPopravni.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Implementation.UseCases.Commands
{
    public class EfRegisterUser : EFUseCase, ICreateUser
    {
        public int Id => 6;
        public string Name => "Create User";
        private CreateUserValidator _validator;

        public EfRegisterUser(popravniContext context, CreateUserValidator validator)
            : base(context)
        {
            _validator = validator;
        }

        public void Execute(CreateUserDTO data)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(data.Password);
            _validator.ValidateAndThrow(data);
            aspPopravni.Domain.Entities.User user = new aspPopravni.Domain.Entities.User
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Password = data.Password,
                RoleId = data.RoleId
            };
            Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}
