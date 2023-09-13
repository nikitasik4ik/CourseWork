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
    public class StuffsController : Controller
    {
        private readonly dbnDbContext _context;

        public StuffsController(dbnDbContext context)
        {
            _context = context;
        }

        // GET: Stuffs
        public async Task<IActionResult> Index()
        {
            var dbnDbContext = _context.Stuffs.Include(s => s.Post);
            return View(await dbnDbContext.ToListAsync());
        }

        // GET: Stuffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stuffs == null)
            {
                return NotFound();
            }

            var stuff = await _context.Stuffs
                .Include(s => s.Post)
                .FirstOrDefaultAsync(m => m.StuffId == id);
            if (stuff == null)
            {
                return NotFound();
            }

            return View(stuff);
        }

        // GET: Stuffs/Create
        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Posts, "PostId", "PostId");
            return View();
        }

        // POST: Stuffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StuffId,FullNameStuff,PostId")] Stuff stuff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stuff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "PostId", "NamePost", stuff.PostId);
            return View(stuff);
        }

        // GET: Stuffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stuffs == null)
            {
                return NotFound();
            }

            var stuff = await _context.Stuffs.FindAsync(id);
            if (stuff == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "PostId", "NamePost", stuff.PostId);
            return View(stuff);
        }

        // POST: Stuffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StuffId,FullNameStuff,PostId")] Stuff stuff)
        {
            if (id != stuff.StuffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stuff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StuffExists(stuff.StuffId))
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
            ViewData["PostId"] = new SelectList(_context.Posts, "PostId", "NamePost", stuff.PostId);
            return View(stuff);
        }

        // GET: Stuffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stuffs == null)
            {
                return NotFound();
            }

            var stuff = await _context.Stuffs
                .Include(s => s.Post)
                .FirstOrDefaultAsync(m => m.StuffId == id);
            if (stuff == null)
            {
                return NotFound();
            }

            return View(stuff);
        }

        // POST: Stuffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stuffs == null)
            {
                return Problem("Entity set 'dbnDbContext.Stuffs'  is null.");
            }
            var stuff = await _context.Stuffs.FindAsync(id);
            if (stuff != null)
            {
                _context.Stuffs.Remove(stuff);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StuffExists(int id)
        {
          return (_context.Stuffs?.Any(e => e.StuffId == id)).GetValueOrDefault();
        }
    }
}
