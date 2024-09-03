using aspPopravni.Domain.Entities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.DataAccess
{
    public class popravniContext : DbContext
    {
        private readonly string _connectionString;

        public popravniContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public popravniContext()
        {
            _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=PopravniASP;Integrated Security=True;Trust Server Certificate=True";
        }

        public popravniContext(DbContextOptions options) : base(options) 
        {
            _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=PopravniASP;Integrated Security=True;Trust Server Certificate=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = 1,
                    Source = "default.png"
                }
            );
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "User"
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "user@library.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("user123"),
                    RoleId = 2
                },
                new User
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "admin@library.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    RoleId = 1
                }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "J. K. Rowling"
                },
                new Author
                {
                    Id = 2,
                    Name = "Stephenie Meyer"
                },
                new Author
                {
                    Id = 3,
                    Name = "Suzanne Collins"
                },
                new Author
                {
                    Id = 4,
                    Name = "C. S. Lewis"
                }
            );

            modelBuilder.Entity<UseCase>().HasData(
                new UseCase
                {
                    Id = 1,
                    Name = "Search Books"
                },
                new UseCase
                {
                    Id = 2,
                    Name = "Search Users"
                },
                new UseCase
                {
                    Id = 3,
                    Name = "Search Loans"
                },
                new UseCase
                {
                    Id = 4,
                    Name = "Search Returns"
                },
                new UseCase
                {
                    Id = 5,
                    Name = "Check Book Availability"
                },
                new UseCase
                {
                    Id = 6,
                    Name = "Register User"
                },
                new UseCase
                {
                    Id = 7,
                    Name = "Create Book"
                },
                new UseCase
                {
                    Id = 8,
                    Name = "Create Loan"
                },
                new UseCase
                {
                    Id = 10,
                    Name = "Update Book"
                },
                new UseCase
                {
                    Id = 11,
                    Name = "Delete Loan"
                }
            );
            modelBuilder.Entity<RoleUseCase>().HasData(
                new RoleUseCase
                {
                    Id = 1,
                    RoleId = 1,
                    UseCaseId = 1
                },
                new RoleUseCase
                {
                    Id = 2,
                    RoleId = 1,
                    UseCaseId = 2
                },
                new RoleUseCase
                {
                    Id = 3,
                    RoleId = 1,
                    UseCaseId = 3
                },
                new RoleUseCase
                {
                    Id = 4,
                    RoleId = 1,
                    UseCaseId = 4
                },
                new RoleUseCase
                {
                    Id = 5,
                    RoleId = 1,
                    UseCaseId = 5
                },
                new RoleUseCase
                {
                    Id = 6,
                    RoleId = 1,
                    UseCaseId = 6
                },
                new RoleUseCase
                {
                    Id = 7,
                    RoleId = 1,
                    UseCaseId = 7
                },
                new RoleUseCase
                {
                    Id = 8,
                    RoleId = 1,
                    UseCaseId = 8
                },
                new RoleUseCase
                {
                    Id = 9,
                    RoleId = 1,
                    UseCaseId = 10
                },
                new RoleUseCase
                {
                    Id = 10,
                    RoleId = 1,
                    UseCaseId = 11
                },
                new RoleUseCase
                {
                    Id = 11,
                    RoleId = 2,
                    UseCaseId = 1
                },
                new RoleUseCase
                {
                    Id = 12,
                    RoleId = 2,
                    UseCaseId = 8
                },
                new RoleUseCase
                {
                    Id = 13,
                    RoleId = 2,
                    UseCaseId = 5
                }
            );
            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Drama"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Fantasy"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Action"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Romance"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Adventure"
                }
            );
            modelBuilder.Entity<Library>().HasData(
                new Library
                {
                    Id = 1,
                    City = "London",
                    Name = "The British Library",
                    Address = "13 Cornelia Street"
                },
                new Library
                {
                    Id = 2,
                    City = "London",
                    Name = "Kensington Central Library",
                    Address = "12 Philimore Walk"
                }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Harry Potter and the Deathly Hallows",
                    Description = "Harry Potter and the Deathly Hallows is a fantasy novel written by British author J.K. Rowling and the seventh and final novel in the Harry Potter series.",
                    AuthorId = 1,
                    PublicationYear = "2010",
                },
                new Book
                {
                    Id = 2,
                    Title = "Twilight: New Moon",
                    Description = "New Moon is a 2006 romantic fantasy novel by author Stephenie Meyer. The second installment in the Twilight series, the novel continues the story of Bella Swan and her relationship with vampire Edward Cullen as she enters her senior year of high school.",
                    AuthorId = 2,
                    PublicationYear = "2006"
                },
                new Book
                {
                    Id = 3,
                    Title = "The Hunger Games: Catching Fire",
                    Description = "Catching Fire is a 2009 dystopian young adult fiction novel by the American novelist Suzanne Collins, the second book in The Hunger Games series.",
                    AuthorId = 3,
                    PublicationYear = "2009"
                },
                new Book
                {
                    Id = 4,
                    Title = "The Hunger Games: The Ballad of Songbirds and Snakes",
                    Description = "The Ballad of Songbirds and Snakes is a dystopian action-adventure novel written by the American author Suzanne Collins. It is the prequel to the original The Hunger Games trilogy, set 64 years before the events of the first novel.",
                    AuthorId = 3,
                    PublicationYear = "2020"
                },
                new Book
                {
                    Id = 5,
                    Title = "The Last Battle",
                    Description = "The Last Battle is a portal fantasy novel for children by C.S. Lewis, published by The Bodley Head in 1956. It is the seventh and final novel in The Chronicles of Narnia.",
                    AuthorId = 4,
                    PublicationYear = "1956"
                },
                new Book
                {
                    Id = 6,
                    Title = "Harry Potter and the Prisoner of Azkaban",
                    Description = "Harry Potter and the Prisoner of Azkaban is a fantasy novel written by the British author J.K. Rowling. It is the third installment in the Harry Potter series.",
                    AuthorId = 1,
                    PublicationYear = "1999"
                }
            );   
            modelBuilder.Entity<BookGenre>().HasData(
                new BookGenre
                {
                    Id = 1,
                    BookId = 2,
                    GenreId = 2
                },
                new BookGenre
                {
                    Id = 2,
                    BookId = 2,
                    GenreId = 4
                },
                new BookGenre
                {
                    Id = 3,
                    BookId = 5,
                    GenreId = 2
                },
                new BookGenre
                {
                    Id = 4,
                    BookId = 5,
                    GenreId = 5
                },
                new BookGenre
                {
                    Id = 5,
                    BookId = 3,
                    GenreId = 1
                },
                new BookGenre
                {
                    Id = 6,
                    BookId = 3,
                    GenreId = 2
                },
                new BookGenre
                {
                    Id = 7,
                    BookId = 3,
                    GenreId = 5
                },
                new BookGenre
                 {
                     Id = 8,
                     BookId = 4,
                     GenreId = 1
                 },
                new BookGenre
                {
                    Id = 9,
                    BookId = 4,
                    GenreId = 2
                },
                new BookGenre
                {
                    Id = 10,
                    BookId = 4,
                    GenreId = 5
                },
                new BookGenre
                {
                    Id = 11,
                    BookId = 6,
                    GenreId = 1
                },
                new BookGenre
                {
                    Id = 12,
                    BookId = 6,
                    GenreId = 2,
                },
                new BookGenre
                {
                    Id = 13,
                    BookId = 6,
                    GenreId = 5
                },
                new BookGenre
                {
                    Id = 14,
                    BookId = 1,
                    GenreId = 5
                },
                new BookGenre
                {
                    Id = 15,
                    BookId = 1,
                    GenreId = 1
                }
            );
            modelBuilder.Entity<Loan>().HasData(
                new Loan
                {
                    Id = 1,
                    UserId = 1
                }
            );
            modelBuilder.Entity<LoanItem>().HasData(
                new LoanItem
                {
                    Id = 1,
                    LoanId = 1,
                    BookId = 3
                },
                new LoanItem
                {
                    Id = 2,
                    LoanId = 1,
                    BookId = 2
                }
            );
            modelBuilder.Entity<LibraryBook>().HasData(
               new LibraryBook
               {
                   Id = 1,
                   LibraryId = 1,
                   BookId = 1
               },
               new LibraryBook
               {
                   Id = 2,
                   LibraryId = 1,
                   BookId = 2
               },
               new LibraryBook
               {
                   Id = 3,
                   LibraryId = 1,
                   BookId = 4
               },
               new LibraryBook
               {
                   Id = 4,
                   LibraryId = 1,
                   BookId = 3
               },
               new LibraryBook
               {
                   Id = 5,
                   LibraryId = 2,
                   BookId = 1
               },
               new LibraryBook
               {
                   Id = 6,
                   LibraryId = 2,
                   BookId = 6
               },
               new LibraryBook
               {
                   Id = 7,
                   LibraryId = 2,
                   BookId = 4
               },
               new LibraryBook
               {
                   Id = 8,
                   LibraryId = 2,
                   BookId = 5
               }
           );
        }
        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.CreatedAt = DateTime.UtcNow;
                    }
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.ModifiedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UseCase> UseCases { get; set; }
        public DbSet<RoleUseCase> RolesUseCases { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookGenre> BooksGenres { get; set; }
        public DbSet<LibraryBook> LibrariesBooks { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanItem> LoanItems { get; set; }
    }
}
