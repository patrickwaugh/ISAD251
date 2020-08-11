using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISAD251_WebApp.Models;

namespace ISAD251_WebApp.Controllers
{
    public class DeadlinesController : Controller
    {
        private readonly ISAD251_PWaughContext _context;

        public DeadlinesController(ISAD251_PWaughContext context)
        {
            _context = context;
        }

        // GET: Deadlines
        public async Task<IActionResult> Index(int id, bool is_parent)
        {
            if (is_parent == true)
            {
                var iSAD251_PWaughContext = _context.Deadline.Include(d => d.User).OrderBy(a => a.DeadlineDate); ;
                return View(await iSAD251_PWaughContext.ToListAsync());
            }
            else
            {
                var iSAD251_PWaughContext = _context.Deadline.Include(d => d.User).Where(a => a.UserId == id).OrderBy(a => a.DeadlineDate); ;
                return View(await iSAD251_PWaughContext.ToListAsync());
            }



        }

        // GET: Deadlines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deadline = await _context.Deadline
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DeadlineId == id);
            if (deadline == null)
            {
                return NotFound();
            }

            return View(deadline);
        }

        // GET: Deadlines/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName");
            return View();
        }

        // POST: Deadlines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeadlineId,DeadlineTitle,DeadlineDate,DeadlineNotes,IsCompleted,UserId")] Deadline deadline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deadline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName", deadline.UserId);
            return View(deadline);
        }

        // GET: Deadlines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deadline = await _context.Deadline.FindAsync(id);
            if (deadline == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName", deadline.UserId);
            return View(deadline);
        }

        // POST: Deadlines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeadlineId,DeadlineTitle,DeadlineDate,DeadlineNotes,IsCompleted,UserId")] Deadline deadline)
        {
            if (id != deadline.DeadlineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deadline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeadlineExists(deadline.DeadlineId))
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
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName", deadline.UserId);
            return View(deadline);
        }

        // GET: Deadlines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deadline = await _context.Deadline
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DeadlineId == id);
            if (deadline == null)
            {
                return NotFound();
            }

            return View(deadline);
        }

        // POST: Deadlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deadline = await _context.Deadline.FindAsync(id);
            _context.Deadline.Remove(deadline);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeadlineExists(int id)
        {
            return _context.Deadline.Any(e => e.DeadlineId == id);
        }
    }
}
