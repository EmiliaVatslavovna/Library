using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly MyAppDbContext _appDbContext;
        public BookController(MyAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var books = _appDbContext.Books.Include("Authors");
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
            var authors = _appDbContext.Authors.ToList();
            ViewBag.Authors = new SelectList(authors, "Id", "Name");
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            _appDbContext.Books.Add(model);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
