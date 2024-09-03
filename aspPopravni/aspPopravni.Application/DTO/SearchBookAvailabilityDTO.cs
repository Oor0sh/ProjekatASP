using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.DTO
{
    public class SearchBookAvailabilityDTO : PagedSearchDTO
    {
        public string Book { get; set; } = "";
        public int BookId { get; set; } = 0;
    }
}
