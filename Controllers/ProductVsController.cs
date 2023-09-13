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
    public class ProductVsController : Controller
    {
        private readonly dbnDbContext _context;

        public ProductVsController(dbnDbContext context)
        {
            _context = context;
        }

        // GET: ProductVs
        public async Task<IActionResult> Index()
        {
            var dbnDbContext = _context.ProductVs.Include(p => p.Type);
            return View(await dbnDbContext.ToListAsync());
        }

        // GET: ProductVs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductVs == null)
            {
                return NotFound();
            }

            var productV = await _context.ProductVs
                .Include(p => p.Type)
                .FirstOrDefaultAsync(m => m.ViewId == id);
            if (productV == null)
            {
                return NotFound();
            }

            return View(productV);
        }

        // GET: ProductVs/Create
        public IActionResult Create()
        {
            ViewData["TypeId"] = new SelectList(_context.ProductTs, "TypeId", "NameType");
            return View();
        }

        // POST: ProductVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ViewId,TypeId,NameView")] ProductV productV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeId"] = new SelectList(_context.ProductTs, "TypeId", "TypeId", productV.TypeId);
            return View(productV);
        }

        // GET: ProductVs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductVs == null)
            {
                return NotFound();
            }

            var productV = await _context.ProductVs.FindAsync(id);
            if (productV == null)
            {
                return NotFound();
            }
            ViewData["TypeId"] = new SelectList(_context.ProductTs, "TypeId", "NameType", productV.TypeId);
            return View(productV);
        }

        // POST: ProductVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ViewId,TypeId,NameView")] ProductV productV)
        {
            if (id != productV.ViewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductVExists(productV.ViewId))
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
            ViewData["TypeId"] = new SelectList(_context.ProductTs, "TypeId", "TypeId", productV.TypeId);
            return View(productV);
        }

        // GET: ProductVs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductVs == null)
            {
                return NotFound();
            }

            var productV = await _context.ProductVs
                .Include(p => p.Type)
                .FirstOrDefaultAsync(m => m.ViewId == id);
            if (productV == null)
            {
                return NotFound();
            }

            return View(productV);
        }

        // POST: ProductVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductVs == null)
            {
                return Problem("Entity set 'dbnDbContext.ProductVs'  is null.");
            }
            var productV = await _context.ProductVs.FindAsync(id);
            if (productV != null)
            {
                _context.ProductVs.Remove(productV);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductVExists(int id)
        {
          return (_context.ProductVs?.Any(e => e.ViewId == id)).GetValueOrDefault();
        }
    }
}
