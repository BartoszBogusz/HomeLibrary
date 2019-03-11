using HomeLibrary.Application;
using Microsoft.AspNetCore.Mvc;

namespace HomeLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var list = _bookService.Get();
            return View(list);
        }
    }
}