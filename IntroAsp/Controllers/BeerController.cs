using IntroAsp.Models;
using IntroAsp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IntroAsp.Controllers
{
    public class BeerController : Controller
    {
        private readonly PubContext _context;
        public BeerController(PubContext context) {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var beers = _context.Beers.Include(b => b.Brand);
            return View(await beers.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name");
            return View();
        }
        [HttpPost]
        //Para asegurar de recibir la informacion de nuestro propio formulario
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Create(BeerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var beer = new Beer()
                {
                    Name = model.Name,
                    BrandId = model.BrandId
                };
                _context.Add(beer);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Cerveza creada con exito";
                return RedirectToAction(nameof(Index));

            }
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name",model.BrandId);
            return View(model);
        }
  
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var beer = await _context.Beers.FindAsync(id);
            if (beer == null)
            {
                return NotFound();
            }

            var model = new BeerViewModel
            {
                BeerId = beer.BeerId,
                Name = beer.Name,
                BrandId = beer.BrandId.GetValueOrDefault()
            };

            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name", model.BrandId);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Beer beer)
        {
            
                _context.Beers.Update(beer);
                await _context.SaveChangesAsync();
                ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name", beer.BrandId);
                return RedirectToAction(nameof(Index));  

    }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Beer beer = await _context.Beers.FirstAsync
                (b => b.BeerId == id);
            _context.Beers.Remove(beer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
