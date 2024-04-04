using Microsoft.AspNetCore.Mvc;
   using BGCakes.Data;
using BGCakes.Models;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;


namespace BGCakes.Controllers
{
    public class BGCakes : Controller
    {
        private readonly BgContext _context;
        public BGCakes(BgContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var cakes = from c in _context.Cakes
                       select c;
            if(!string.IsNullOrEmpty(searchString))
            {
                cakes = cakes.Where(c => c.Name.Contains(searchString));
                return View(await _context.Cakes.ToListAsync());     
            }
            return View(await _context.Cakes.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            var cake = await _context.Cakes
                .Include(ca => ca.CakeIngredients)
                .ThenInclude(i => i.Ingredient)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(cake == null)
            {
                return NotFound();
            }
            return View(cake);
        }

    }
}
