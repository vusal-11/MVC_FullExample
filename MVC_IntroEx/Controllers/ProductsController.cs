using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_IntroEx.Data;
using MVC_IntroEx.Models;

namespace MVC_IntroEx.Controllers
{
    public class ProductsController : Controller
    {

        private readonly WebAppMVCContext _context;


        public ProductsController(WebAppMVCContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return _context.Products !=null ? View(await _context.Products.ToListAsync()) : Problem("Products not found");
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {

            if(ModelState.IsValid)
            {

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);

        }


        public async Task<IActionResult> Details(int? id)
        {

            if(id == null || _context.Products==null)
            {

                return NotFound();

            }

            var product = await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null || _context.Products == null)
            {

                return NotFound();

            }


            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,Product product)
        {

            if (id != product.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
           
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
    
              return View(product);


        }


    }
}
