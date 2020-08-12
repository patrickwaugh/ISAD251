using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ISAD251_WebApp.Models;

namespace ISAD251_WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeadlinesApiController : ControllerBase
    {
        private readonly ISAD251_PWaughContext _context;

        public DeadlinesApiController(ISAD251_PWaughContext context)
        {
            _context = context;
        }

        // Handles API calls that request all deadline records
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deadline>>> GetDeadline()
        {
            return await _context.Deadline.ToListAsync();
        }

        // Handles API calls that request a specific deadline record
        [HttpGet("{id}")]
        public async Task<ActionResult<Deadline>> GetDeadline(int id)
        {
            var deadline = await _context.Deadline.FindAsync(id);

            if (deadline == null)
            {
                return NotFound();
            }

            return deadline;
        }

        // Handles API calls that edit a specific deadline record
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeadline(int id, Deadline deadline)
        {
            if (id != deadline.DeadlineId)
            {
                return BadRequest();
            }

            _context.Entry(deadline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeadlineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Handles API calls that request to create a new deadline record
        [HttpPost]
        public async Task<ActionResult<Deadline>> PostDeadline(Deadline deadline)
        {
            _context.Deadline.Add(deadline);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeadline", new { id = deadline.DeadlineId }, deadline);
        }

        // Handles API calls to delete a specific record
        [HttpDelete("{id}")]
        public async Task<ActionResult<Deadline>> DeleteDeadline(int id)
        {
            var deadline = await _context.Deadline.FindAsync(id);
            if (deadline == null)
            {
                return NotFound();
            }

            _context.Deadline.Remove(deadline);
            await _context.SaveChangesAsync();

            return deadline;
        }

        private bool DeadlineExists(int id)
        {
            return _context.Deadline.Any(e => e.DeadlineId == id);
        }
    }
}
