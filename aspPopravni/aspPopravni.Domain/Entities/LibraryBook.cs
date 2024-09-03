using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace aspPopravni.Domain.Entities
{
    public class LibraryBook : Entity
    {
        public int LibraryId { get; set; }
        public virtual Library LibraryLB { get; set; }
        public int BookId { get; set; }
        public virtual Book BookLB { get; set; }
    }
}
