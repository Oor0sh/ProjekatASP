using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.DTO
{
    public class CreateLoanDTO
    {
        public int UserId { get; set; }
        public IEnumerable<LoanItemDTO> LoanItems { get; set; }
    }
}
