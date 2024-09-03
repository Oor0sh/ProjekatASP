using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.DTO
{
    public class PagedResponseDTO<TDTO>
        where TDTO : class
    {
        public IEnumerable<TDTO> Data { get; set; }
        public int PerPage { get; set; }
        public int TotalCount { get; set; }
        public int Pages
        {
            get
            {
                return (int)Math.Ceiling((double)TotalCount / PerPage);
            }
        }
        public int CurrentPage { get; set; }
    }
}
