using LabProject.Models.Services;
using LabProject.Models.GravityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LabProject.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        public IActionResult List(int pageNumber = 1, int pageSize = 10)
        {
            var (books, totalBooks) = _bookService.GetBooks(pageNumber, pageSize);

            ViewData["CurrentPage"] = pageNumber;
            ViewData["TotalPages"] = (int)Math.Ceiling((double)totalBooks / pageSize);

            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        public IActionResult Authors(int id)
        {
            var authors = _bookService.GetAuthorsByBookId(id);
            if (authors == null || !authors.Any())
                return NotFound();


            ViewData["BookId"] = id;
            return View("BookAuthors", authors);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(BookModel model)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddBook(model);
                return RedirectToAction("List");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BookModel model)
        {
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(id, model);
                return RedirectToAction("List");
            }

            return View(model);
        }
    }
}