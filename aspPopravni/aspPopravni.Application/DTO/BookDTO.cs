using aspPopravni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string PublicationYear { get; set; }
        public string ImageSource { get; set; }
        public IEnumerable<string> Genres { get; set; }
    }
}
