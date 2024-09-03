using aspPopravni.Application.Commands;
using aspPopravni.Application.DTO;
using aspPopravni.DataAccess;
using aspPopravni.Domain.Entities;
using aspPopravni.Implementation.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Implementation.UseCases.Commands
{
    public class EFCreateBook : EFUseCase, ICreateBook
    {
        public int Id => 7;
        public string Name => "Create Book";
        private CreateBookValidator _validator;
        public EFCreateBook(popravniContext context, CreateBookValidator validator) : base(context)
        {
            _validator = validator;
        }
        public void Execute(CreateBookDTO data)
        {
            _validator.ValidateAndThrow(data);
            Book b = new Book
            {
                AuthorId = data.AuthorId,
                Title = data.Title,
                Description = data.Description,
                PublicationYear = data.PublicationYear
            };
            Context.Books.Add(b);
            Context.SaveChanges();

            int lastInsertedBook = b.Id; 
            List<BookGenre> booksGenres = new List<BookGenre>();
            foreach (int genreId in data.GenreIds)
            {
                booksGenres.Add(new BookGenre
                {
                    BookId = lastInsertedBook,
                    GenreId = genreId
                });
            }
            Context.BooksGenres.AddRange(booksGenres);
            Context.SaveChanges();
        }

    }
}
