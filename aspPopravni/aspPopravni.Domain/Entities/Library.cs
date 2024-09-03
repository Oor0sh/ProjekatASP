using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Domain.Entities
{
    public class Library : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public virtual ICollection<LibraryBook> LibraryBooks { get; set; } = new HashSet<LibraryBook>();
    }
}
