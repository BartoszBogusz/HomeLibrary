using HomeLibrary.Infrastructure;
using HomeLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace HomeLibrary.Application
{
    public interface IBookService
    {
        List<ReadBookViewModel> Get();
    }

    public class BookService : IBookService
    {
        private readonly HomeLibraryContext _context;

        public BookService(HomeLibraryContext context)
        {
            _context = context;
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
