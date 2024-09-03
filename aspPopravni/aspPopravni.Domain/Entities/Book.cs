using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Domain.Entities
{
    public class Book : Entity
    {
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PublicationYear { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; } = new HashSet<BookGenre>();
        public virtual ICollection<LibraryBook> BookLibraries { get; set; } = new HashSet<LibraryBook>();
    }
}
