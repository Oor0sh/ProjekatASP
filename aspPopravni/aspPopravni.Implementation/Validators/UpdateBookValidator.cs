using aspPopravni.Application.DTO;
using aspPopravni.DataAccess;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Implementation.Validators
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookDTO>
    {
        private readonly popravniContext _context;
        public UpdateBookValidator(popravniContext context)
        {
            _context = context;
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Title).MinimumLength(2);
            RuleFor(x => x.Description).MinimumLength(2);
            RuleFor(x => x.AuthorId).GreaterThan(0).Must(InvalidAuthorId).WithMessage("Invalid Author Id");
            RuleFor(x => x.PublicationYear).MaximumLength(4);
            RuleFor(x => x.GenreIds).Must(InvalidGenreIds).WithMessage("Invalid Genre Ids");
        }
        private bool InvalidGenreIds(IEnumerable<int>? genreIds)
        {
            if (genreIds == null)
                return true;
            bool value = true;
            foreach (int id in genreIds)
            {
                if (!_context.Genres.Any(x => x.Id == id))
                    value = false;
            }
            return value;
        }
        private bool InvalidAuthorId(int? id)
        {
            if (!id.HasValue)
                return true;
            bool value = true;
            if (!_context.Authors.Any(x => x.Id == id))
            {
                value = false;
            }
            return value;
        }
    }
}
