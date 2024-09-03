using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<UseCaseLog> UseCaseLogs { get; set; } = new HashSet<UseCaseLog>();
        public virtual ICollection<Loan> Loans { get; set; } = new HashSet<Loan>();
    }
}
