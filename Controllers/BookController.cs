using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Data.Migrations;
using MyLibrary.Models;
using System.Net.Http.Headers;

namespace MyLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public IActionResult Index()
        {
            var books = _context.Books.Include("Authors");
            return View(books);
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            LoadAuthors();
            return View();
        }

        [NonAction]
        private void LoadAuthors()
        {
            var authors = _context.Authors.ToList();
            ViewBag.Authors = new SelectList(authors, "Id", "Name");
        }
 
        [HttpPost]
        public IActionResult Create(Book model)
        {  
                _context.Books.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                NotFound();
            }
            LoadAuthors();
            var book = _context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book model)
        {
            ModelState.Remove("Authors");
            if (ModelState.IsValid)
            {
                _context.Books.Update(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                NotFound();
            }
            LoadAuthors();
            var book = _context.Books.Find(id);
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Book model)
        {
            _context.Books.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));        
        }
    }
}