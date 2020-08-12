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
    public class AppointmentsController : Controller
    {
        private readonly ISAD251_PWaughContext _context;

        public AppointmentsController(ISAD251_PWaughContext context)
        {
            _context = context;
        }


        // Function to retrieve a user's appointment records
        public async Task<IActionResult> Index(int id, bool is_parent)
        {
            // If the user is a parent user then they have access to the records of any user
            if (is_parent == true)
            {
                var iSAD251_PWaughContext = _context.Appointment.Include(a => a.User).OrderBy(a => a.ApptDate);

                return View(await iSAD251_PWaughContext.ToListAsync());
            }
            // If the user is a child they can only access their own records
            else
            {
                var iSAD251_PWaughContext = _context.Appointment.Include(a => a.User).Where(a => a.UserId == id).OrderBy(a => a.ApptDate);

                return View(await iSAD251_PWaughContext.ToListAsync());
            }       
        }

        // Function to return the details of a selected record
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ApptId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // Functions to create a new appointment record for the current user
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApptId,ApptTitle,ApptDate,ApptLocation,ApptDuration,ApptNotes,UserId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName", appointment.UserId);
            return View(appointment);
        }

        // Functions to edit a specified record
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName", appointment.UserId);
            return View(appointment);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApptId,ApptTitle,ApptDate,ApptLocation,ApptDuration,ApptNotes,UserId")] Appointment appointment)
        {
            if (id != appointment.ApptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.ApptId))
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
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName", appointment.UserId);
            return View(appointment);
        }

        // Functions to delete a specified record
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ApptId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.ApptId == id);
        }
    }
}
