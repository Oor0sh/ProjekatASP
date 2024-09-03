using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.DTO
{
    public class UserLoansDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int LoanId { get; set; }
        public DateTime LoanedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
        public IEnumerable<GetLoanItemDTO> LoanedBooks { get; set; }
    }
}
