using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Domain.Entities
{
    public class Loan : Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<LoanItem> LoanItems { get; set; } = new HashSet<LoanItem>();

        public DateTime? Returned { get; set; }
    }
}
