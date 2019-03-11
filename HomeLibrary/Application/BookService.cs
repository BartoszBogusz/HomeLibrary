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
                    Title = x.Title,
                    AuthorFirstName = x.AuthorFirstName,
                    AuthorLastName = x.AuthorLastName,
                    Year = x.Year
                }).ToList();

            return list;
        }
    }
}
