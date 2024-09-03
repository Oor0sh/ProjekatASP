using aspPopravni.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.DTO
{
    public class LibraryBookDTO
    {
        public int LibraryId { get; set; }
        public string LibraryName { get; set; }
        public int BookId {  get; set; }
        public Library Library { get; set; }
        public Book Book { get; set; }
    }
}
