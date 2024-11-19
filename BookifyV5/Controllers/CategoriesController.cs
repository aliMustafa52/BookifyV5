using BookifyV5.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookifyV5.Controllers
{
    public class CategoriesController(ApplicationDbContext context) : Controller
    {
        private ApplicationDbContext _context = context;

        [HttpGet]
        public IActionResult Index()
        {
            // TODO: use viewModel
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Form");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Form", model);

            var category = new Category { Name = model.Name };
            _context.Add(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            if (category is null)
                return NotFound();

            var categorViewModel = new CategoryFormViewModel
            {
                Id = id,
                Name = category.Name
            };
            return View("Form",categorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Form", model);

            var category = _context.Categories.Find(model.Id);
            if (category is null)
                return NotFound();

            category.Name = model.Name;
            category.LastUpdatedOn = DateTime.Now;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

