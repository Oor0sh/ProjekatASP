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
    public class EFGetUsers : EFUseCase, IGetUsers
    {
        public EFGetUsers(popravniContext context) : base(context) { }
        public int Id => 2;
        public string Name => "Search Users";
        public PagedResponseDTO<UserDTO> Execute(SearchUserDTO search)
        {
            var query = Context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Email.Contains(search.Keyword)
                                    || x.FirstName.Contains(search.Keyword)
                                    || x.LastName.Contains(search.Keyword));
            }
            int totalCount = query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponseDTO<UserDTO>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                Data = query.Select(x => new UserDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Role = x.Role.Name
                }).ToList(),
                PerPage = perPage
            };
        }
    }
}
