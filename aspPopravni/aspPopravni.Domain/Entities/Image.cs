using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Domain.Entities
{
    public class Image : Entity
    {
        public string Source { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
