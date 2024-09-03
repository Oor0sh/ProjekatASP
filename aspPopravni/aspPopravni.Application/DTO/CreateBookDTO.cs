using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.DTO
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public string PublicationYear { get; set; }
        public IEnumerable<int> GenreIds { get; set; }
    }
}
