using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.DTO
{
    public class SearchUserLoansDTO : PagedSearchDTO
    {
        public int UserId { get; set; } = 0;
        public string Name { get; set; } = "";
    }
}
