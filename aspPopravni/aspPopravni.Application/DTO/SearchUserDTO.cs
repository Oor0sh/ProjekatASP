using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.DTO
{
    public class SearchUserDTO : PagedSearchDTO
    {
        public string Keyword { get; set; } = "";
    }
}
