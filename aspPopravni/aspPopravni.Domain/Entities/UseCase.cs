using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Domain.Entities
{
    public class UseCase : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<UseCaseLog> UseCaseLogs { get; set; } = new HashSet<UseCaseLog>();
        public virtual ICollection<RoleUseCase> UseCaseRoles { get; set; } = new HashSet<RoleUseCase>();
    }
}
