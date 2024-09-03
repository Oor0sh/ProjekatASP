using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Domain.Entities
{
    public class Author : Entity
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
