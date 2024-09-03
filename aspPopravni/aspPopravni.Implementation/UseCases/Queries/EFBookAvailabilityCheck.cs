using aspPopravni.Application.DTO;
using aspPopravni.Application.Queries;
using aspPopravni.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Implementation.UseCases.Queries
{
    public class EFBookAvailabilityCheck : EFUseCase, IBookAvailabilityCheck
    {
        public EFBookAvailabilityCheck(popravniContext context) : base(context) { }
        public int Id => 5;
        public string Name => "Check Book Availability";

        public PagedResponseDTO<BookAvailabilityDTO> Execute(SearchBookAvailabilityDTO search)
        {
            var query = Context.Books.AsQueryable();
            if (!string.IsNullOrEmpty(search.Book))
            {
                query = query.Where(x => x.Title == search.Book);
            }
            if (search.BookId > 0)
            {
                query = query.Where(x => x.Id == search.BookId);
            }
            int totalCount = query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);
            return new PagedResponseDTO<BookAvailabilityDTO>
            {
                Data = query.Select(x => new BookAvailabilityDTO
                {
                    BookId = x.Id,
                    Title = x.Title,
                    AvailableLibraries = x.BookLibraries.Select(x => new LibraryBookDTO
                    {
                        LibraryId = x.LibraryLB.Id,
                        LibraryName = x.LibraryLB.Name
                    })
                }).ToList(),
                TotalCount = totalCount,
                CurrentPage = page,
                PerPage = perPage
            };

        }
    }
}
