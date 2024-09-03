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
    public class EFGetBooks : EFUseCase, IGetBooks
    {
        public EFGetBooks(popravniContext context) : base(context) { }
        public int Id => 1;
        public string Name => "Search Books";
        public PagedResponseDTO<BookDTO> Execute(SearchBookDTO search)
        {
            var query = Context.Books.AsQueryable();
            if (!string.IsNullOrEmpty(search.PublicationYear))
            {
                query = query.Where(x => x.PublicationYear == search.PublicationYear);
            }
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Title.Contains(search.Keyword) || x.Description.Contains(search.Keyword));
            }
            if (search.AuthorId > 0)
            {
                query = query.Where(x => x.AuthorId == search.AuthorId);
            }
            if (!string.IsNullOrEmpty(search.Genre))
            {
                query = query.Where(x => x.BookGenres.Any(x => x.Genre.Name == search.Genre));
            }
            int totalCount = query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);
            return new PagedResponseDTO<BookDTO>
            {

                CurrentPage = page,
                TotalCount = totalCount,
                Data = query.Select(x => new BookDTO
                {
                    Id = x.Id,
                    BookId = x.Id,
                    Title = x.Title,
                    Author = x.Author.Name,
                    Description = x.Description,
                    Genres = x.BookGenres.Select(x => x.Genre.Name).ToList(),
                    //ImageSource
                    PublicationYear = x.PublicationYear
                }).ToList(),
                PerPage = perPage
            };
        }
    }
}
