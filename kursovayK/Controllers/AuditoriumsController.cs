using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kursovayK.models;

namespace kursovayK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriumsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuditoriumsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Auditoriums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auditorium>>> GetAuditoriums()
        {
          if (_context.Auditoriums == null)
          {
              return NotFound();
          }
            return await _context.Auditoriums.ToListAsync();
        }

        // GET: api/Auditoriums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auditorium>> GetAuditorium(int id)
        {
          if (_context.Auditoriums == null)
          {
              return NotFound();
          }
            var auditorium = await _context.Auditoriums.FindAsync(id);

            if (auditorium == null)
            {
                return NotFound();
            }

            return auditorium;
        }

        // PUT: api/Auditoriums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuditorium(int id, Auditorium auditorium)
        {
            if (id != auditorium.AuditoriumId)
            {
                return BadRequest();
            }

            _context.Entry(auditorium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditoriumExists(id))
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

        // POST: api/Auditoriums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Auditorium>> PostAuditorium(Auditorium auditorium)
        {
          if (_context.Auditoriums == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Auditoriums'  is null.");
          }
            _context.Auditoriums.Add(auditorium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuditorium", new { id = auditorium.AuditoriumId }, auditorium);
        }

        // DELETE: api/Auditoriums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuditorium(int id)
        {
            if (_context.Auditoriums == null)
            {
                return NotFound();
            }
            var auditorium = await _context.Auditoriums.FindAsync(id);
            if (auditorium == null)
            {
                return NotFound();
            }

            _context.Auditoriums.Remove(auditorium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuditoriumExists(int id)
        {
            return (_context.Auditoriums?.Any(e => e.AuditoriumId == id)).GetValueOrDefault();
        }
    }
}
