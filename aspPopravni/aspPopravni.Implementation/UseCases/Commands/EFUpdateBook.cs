using aspPopravni.Application.Commands;
using aspPopravni.Application.DTO;
using aspPopravni.DataAccess;
using aspPopravni.Domain.Entities;
using aspPopravni.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Implementation.UseCases.Commands
{
    public class EFUpdateBook : EFUseCase, IUpdateBook
    {
        public int Id => 10;
        public string Name => "Update Book";
        private UpdateBookValidator _validator;
        public EFUpdateBook(popravniContext context, UpdateBookValidator validator) : base(context)
        {
            _validator = validator;
        }
        public void Execute(UpdateBookDTO data)
        {

            _validator.ValidateAndThrow(data);
            Book b = Context.Books.Where(x => x.Id == data.Id).FirstOrDefault<Book>();
            if (b != null)
            {
                b.AuthorId = data.AuthorId.HasValue ? data.AuthorId.Value : b.AuthorId;
                b.PublicationYear = string.IsNullOrEmpty(data.PublicationYear) ? data.PublicationYear : b.PublicationYear;
                b.Title = string.IsNullOrEmpty(data.Title) ? data.Title : b.Title;
                b.Description = string.IsNullOrEmpty(data.Description) ? data.Description : b.Description;
                Context.SaveChanges();
            }
            var currentBookGenres = Context.BooksGenres.Where(x => x.BookId == b.Id).ToList();
            if (data.GenreIds != null && data.GenreIds.Any())
            {
                List<BookGenre> bookGenres = new List<BookGenre>();
                foreach (int genreId in data.GenreIds)
                {
                    if (!currentBookGenres.Any(x => x.GenreId == genreId))
                    {
                        bookGenres.Add(new BookGenre
                        {
                            GenreId = genreId,
                            BookId = b.Id
                        });
                    }
                }
                if (bookGenres.Count > 0)
                {
                    Context.BooksGenres.AddRange(bookGenres);
                    Context.SaveChanges();
                }
            }
        }
    }
}
