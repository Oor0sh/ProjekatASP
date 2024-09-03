using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Domain.Entities
{
    public class LoanItem : Entity
    {
        public int LoanId { get; set; }
        public virtual Loan Loan { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
