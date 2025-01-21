using LabProject.Models;
using LabProject.Models.GravityModels;
using LabProject.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabProject.Controllers;

public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult List(int pageNumber = 1, int pageSize = 10)
        {
            var (authors, totalAuthors) = _authorService.GetAuthors(pageNumber, pageSize);

            ViewData["CurrentPage"] = pageNumber;
            ViewData["TotalPages"] = (int)Math.Ceiling((double)totalAuthors / pageSize);

            return View(authors);
        }

        public IActionResult Details(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
                return NotFound();

            return View(author);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AuthorModel model)
        {
            if (ModelState.IsValid)
            {
                _authorService.AddAuthor(model);
                return RedirectToAction("List");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
                return NotFound();

            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, AuthorModel model)
        {
            if (ModelState.IsValid)
            {
                _authorService.UpdateAuthor(id, model);
                return RedirectToAction("List");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _authorService.DeleteAuthor(id);
            return RedirectToAction("List");
        }
    }