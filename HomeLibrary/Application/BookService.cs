using HomeLibrary.Entities;
using HomeLibrary.Infrastructure;
using HomeLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace HomeLibrary.Application
{
    public interface IBookService
    {
        void Create(CreateBookViewModel model);
        List<ReadBookViewModel> Get();
        EditBookViewModel Get(int bookId);
        void Update(EditBookViewModel model);
    }

    public class BookService : IBookService
    {
        private readonly HomeLibraryContext _context;

        public BookService(HomeLibraryContext context)
        {
            _context = context;
        }

        public void Create(CreateBookViewModel model)
        {
            var newBook = new Book
            {
                Title = model.Title,
                AuthorFirstName = model.AuthorFirstName,
                AuthorLastName = model.AuthorLastName,
                Year = model.Year
            };

            _context.Add(newBook);
            _context.SaveChanges();               
        }

        public List<ReadBookViewModel> Get()
        {
            var list = _context.Books
                .Select(x => new ReadBookViewModel
                {
                    BookId = x.BookId,
                    Title = x.Title,
                    AuthorFirstName = x.AuthorFirstName,
                    AuthorLastName = x.AuthorLastName,
                    Year = x.Year
                }).ToList();

            return list;
        }

        public EditBookViewModel Get(int bookId)
        {
            var dbBook = _context.Books
                .Where(x => x.BookId == bookId)
                .Select(x => new EditBookViewModel
                {
                    Title = x.Title,
                    AuthorFirstName = x.AuthorFirstName,
                    AuthorLastName = x.AuthorLastName,
                    Year = x.Year
                }).First();

            return dbBook;
        }

        public void Update(EditBookViewModel model)
        {
            var book = _context.Books
                .First(x => x.BookId == model.BookId);

            book.Title = model.Title;
            book.AuthorFirstName = model.AuthorFirstName;
            book.AuthorLastName = model.AuthorLastName;
            book.Year = model.Year;

            _context.SaveChanges();
        }
    }
}
