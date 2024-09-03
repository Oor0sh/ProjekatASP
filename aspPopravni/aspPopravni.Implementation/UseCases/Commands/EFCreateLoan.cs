using aspPopravni.Application.Commands;
using aspPopravni.Application.DTO;
using aspPopravni.DataAccess;
using aspPopravni.Domain.Entities;
using aspPopravni.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Implementation.UseCases.Commands
{
    public class EFCreateLoan : EFUseCase, ICreateLoan
    {
        public int Id => 8;
        public string Name => "Create Loans";
        private CreateLoanValidator _validator;
        public EFCreateLoan(popravniContext context, CreateLoanValidator validator) : base(context)
        {
            _validator = validator;
        }
        public void Execute(CreateLoanDTO data)
        {
            _validator.ValidateAndThrow(data);
            Loan l = new Loan
            {
                UserId = data.UserId
            };
            Context.Loans.Add(l);
            Context.SaveChanges();

            int lastId = l.Id;
            List<LoanItem> items = new List<LoanItem>();
            foreach (LoanItemDTO item in data.LoanItems)
            {
                items.Add(new LoanItem
                {
                    LoanId = lastId,
                    BookId = item.BookId
                });
            }
            Context.LoanItems.AddRange(items);
            Context.SaveChanges();
        }
    }
}
