using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Domain.Entities
{
    public class UseCaseLog : Entity
    {
        public int UseCaseId { get; set; }
        public virtual UseCase UseCase { get; set; }
        public int? UserId { get; set; }
        public bool IsLoggedIn { get; set; }
        public string UseCaseData { get; set; }
        public virtual User User { get; set; }
    }
}
