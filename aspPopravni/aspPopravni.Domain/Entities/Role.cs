using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Domain.Entities
{
    public class Role : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
        public virtual ICollection<RoleUseCase> RoleUseCases { get; set; } = new HashSet<RoleUseCase>();
    }
}
