using HomeLibrary.Application;
using HomeLibrary.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateBookViewModel model)
        {
            _bookService.Create(model);
            return RedirectToAction("Index");
        }
    }
}