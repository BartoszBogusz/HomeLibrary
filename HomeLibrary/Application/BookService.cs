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
        List<ReadBookViewModel> Get(string sortOrder);
        EditBookViewModel Get(int bookId);
        void Update(EditBookViewModel model);
        void Delete(int bookId);
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

        public List<ReadBookViewModel> Get(string sortOrder)
        {
            var list = _context.Books
                .Select(x => new ReadBookViewModel
                {
                    BookId = x.BookId,
                    Title = x.Title,
                    AuthorFirstName = x.AuthorFirstName,
                    AuthorLastName = x.AuthorLastName,
                    Year = x.Year
                });

            switch (sortOrder)
            {
                case "title_desc":
                    list = list.OrderByDescending(s => s.Title);
                    break;
                case "Name":
                    list = list.OrderBy(s => s.AuthorLastName);
                    break;
                case "name_desc":
                    list = list.OrderByDescending(s => s.AuthorLastName);
                    break;
                default:
                    list = list.OrderBy(x => x.Title);
                    break;
            }

            return list.ToList();
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

        public void Delete(int bookId)
        {
            var item = _context.Books
                .Where(x => x.BookId == bookId)
                .First();

            _context.Remove(item);
            _context.SaveChanges();
        }
    }
}
