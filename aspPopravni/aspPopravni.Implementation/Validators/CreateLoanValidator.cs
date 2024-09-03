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
    public class CreateLoanValidator : AbstractValidator<CreateLoanDTO>
    {
        private readonly popravniContext _context;
        public CreateLoanValidator(popravniContext context)
        {
            _context = context;
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.LoanItems).NotEmpty().Must(InvalidLoanItems).WithMessage("Invalid Loan Items");
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0).Must(InvalidUserId).WithMessage("Invalid User Id");
        }
        private bool InvalidUserId(int id)
        {
            bool value = true;
            if (!_context.Users.Any(x => x.Id == id))
                value = false;
            return value;
        }
        private bool InvalidLoanItems(IEnumerable<LoanItemDTO> items)
        {
            bool value = true;
            foreach (LoanItemDTO dto in items)
            {
                if (!_context.Books.Any(x => x.Id == dto.BookId))
                    value = false;
            }
            return value;
        }
    }
}
