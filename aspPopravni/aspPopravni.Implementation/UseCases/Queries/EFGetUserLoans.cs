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
    public class EFGetUserLoans : EFUseCase, IGetUserLoans
    {
        public EFGetUserLoans(popravniContext context) : base(context) { }
        public int Id => 3;
        public string Name => "Search Loans";
        public PagedResponseDTO<UserLoansDTO> Execute(SearchUserLoansDTO search)
        {
            var query = Context.Loans.AsQueryable();
            if (search.UserId > 0)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.User.FirstName == search.Name || x.User.LastName == search.Name);
            }
            int totalCount = query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);
            return new PagedResponseDTO<UserLoansDTO>
            {
                Data = query.Select(x => new UserLoansDTO
                {
                    UserId = x.UserId,
                    LoanedAt = x.CreatedAt,
                    ReturnedAt = x.Returned,
                    Name = x.User.FirstName + " " + x.User.LastName,
                    LoanedBooks = x.LoanItems.Select(x => new GetLoanItemDTO
                    {
                        BookId = x.BookId,
                        Title = x.Book.Title,
                    }).ToList(),
                    LoanId = x.Id
                }).ToList(),

                CurrentPage = page,
                TotalCount = totalCount,
                PerPage = perPage
            };
        }
    }
}
