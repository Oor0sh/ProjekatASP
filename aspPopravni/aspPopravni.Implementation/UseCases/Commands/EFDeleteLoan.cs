using aspPopravni.Application.Commands;
using aspPopravni.Application.DTO;
using aspPopravni.DataAccess;
using aspPopravni.Domain.Entities;
using aspPopravni.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Implementation.UseCases.Commands
{
    public class EFDeleteLoan : EFUseCase, IDeleteLoan
    {
        public int Id => 11;
        public string Name => "Delete Loans";
        public EFDeleteLoan(popravniContext context) : base(context) { }
        public void Execute(DeleteLoanDTO data)
        {

            Loan l = Context.Loans.Where(x => x.Id == data.LoanId).FirstOrDefault<Loan>();
            if (l != null)
            {
                l.Returned = DateTime.UtcNow;
                Context.SaveChanges();
            }
        }
    }
}
