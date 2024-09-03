using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.DTO
{
    public class BookAvailabilityDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public IEnumerable<LibraryBookDTO> AvailableLibraries { get; set; }
    }
}
