using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using coreCodeFirstRelationshipsApplications.Models;

namespace coreCodeFirstRelationshipsApplications.Controllers
{
    public class AuthorBiographiesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AuthorBiographiesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: AuthorBiographies
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.AuthorBiographies.Include(a => a.Author);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: AuthorBiographies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorBiography = await _context.AuthorBiographies
                .Include(a => a.Author)
                .FirstOrDefaultAsync(m => m.AuthorBiographyId == id);
            if (authorBiography == null)
            {
                return NotFound();
            }

            return View(authorBiography);
        }

        // GET: AuthorBiographies/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "Name");
            return View();
        }

        // POST: AuthorBiographies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorBiographyId,DateOfBirth,PlaceOfBirth,Nationality,Experience,AuthorId")] AuthorBiography authorBiography)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorBiography);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "AuthorId", authorBiography.AuthorId);
            return View(authorBiography);
        }

        // GET: AuthorBiographies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorBiography = await _context.AuthorBiographies.FindAsync(id);
            if (authorBiography == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "Name", authorBiography.AuthorId);
            return View(authorBiography);
        }

        // POST: AuthorBiographies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorBiographyId,DateOfBirth,PlaceOfBirth,Nationality,Experience,AuthorId")] AuthorBiography authorBiography)
        {
            if (id != authorBiography.AuthorBiographyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorBiography);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorBiographyExists(authorBiography.AuthorBiographyId))
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
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "AuthorId", authorBiography.AuthorId);
            return View(authorBiography);
        }

        // GET: AuthorBiographies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorBiography = await _context.AuthorBiographies
                .Include(a => a.Author)
                .FirstOrDefaultAsync(m => m.AuthorBiographyId == id);
            if (authorBiography == null)
            {
                return NotFound();
            }

            return View(authorBiography);
        }

        // POST: AuthorBiographies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorBiography = await _context.AuthorBiographies.FindAsync(id);
            _context.AuthorBiographies.Remove(authorBiography);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorBiographyExists(int id)
        {
            return _context.AuthorBiographies.Any(e => e.AuthorBiographyId == id);
        }
    }
}
