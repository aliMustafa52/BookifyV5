using Microsoft.AspNetCore.Mvc;

namespace BookifyV5.Controllers
{
    public class CategoriesController(ApplicationDbContext context) : Controller
    {
        private ApplicationDbContext _context = context;

        public IActionResult Index()
        {
            // TODO: use viewModel
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
