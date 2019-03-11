using HomeLibrary.Application;
using HomeLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HomeLibrary.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";
            ViewData["CurrentFilter"] = searchString;

            var list = _bookService.Get(sortOrder, searchString);
            return View(list);
        }

        public IActionResult Details(int bookId)
        {
            var book = _bookService.Get(bookId);
            return View(book);
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

        public IActionResult Edit(int bookId)
        {
            var book = _bookService.Get(bookId);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(EditBookViewModel model)
        {
            _bookService.Update(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int bookId)
        {
            _bookService.Delete(bookId);
            return RedirectToAction("Index");
        }
    }
}