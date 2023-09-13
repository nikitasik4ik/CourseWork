using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourseWork.Models;

namespace CourseWork.Controllers
{
    public class ProductTsController : Controller
    {
        private readonly dbnDbContext _context;

        public ProductTsController(dbnDbContext context)
        {
            _context = context;
        }

        // GET: ProductTs
        public async Task<IActionResult> Index()
        {
              return _context.ProductTs != null ? 
                          View(await _context.ProductTs.ToListAsync()) :
                          Problem("Entity set 'dbnDbContext.ProductTs'  is null.");
        }

        // GET: ProductTs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductTs == null)
            {
                return NotFound();
            }

            var productT = await _context.ProductTs
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (productT == null)
            {
                return NotFound();
            }

            return View(productT);
        }

        // GET: ProductTs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,NameType")] ProductT productT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productT);
        }

        // GET: ProductTs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductTs == null)
            {
                return NotFound();
            }

            var productT = await _context.ProductTs.FindAsync(id);
            if (productT == null)
            {
                return NotFound();
            }
            return View(productT);
        }

        // POST: ProductTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeId,NameType")] ProductT productT)
        {
            if (id != productT.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTExists(productT.TypeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productT);
        }

        // GET: ProductTs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductTs == null)
            {
                return NotFound();
            }

            var productT = await _context.ProductTs
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (productT == null)
            {
                return NotFound();
            }

            return View(productT);
        }

        // POST: ProductTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductTs == null)
            {
                return Problem("Entity set 'dbnDbContext.ProductTs'  is null.");
            }
            var productT = await _context.ProductTs.FindAsync(id);
            if (productT != null)
            {
                _context.ProductTs.Remove(productT);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTExists(int id)
        {
          return (_context.ProductTs?.Any(e => e.TypeId == id)).GetValueOrDefault();
        }
    }
}
