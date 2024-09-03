using aspPopravni.Application.DTO;
using aspPopravni.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Implementation.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidator(popravniContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(x => !ctx.Users.Any(u => u.Email == x))
                .WithMessage("Email is already in use.");
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Password).NotEmpty().Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$").WithMessage("Minimum eight characters, at least one uppercase letter, one lowercase letter and one number:");
            RuleFor(x => x.RoleId).NotEmpty().GreaterThan(0);
        }
    }
}
