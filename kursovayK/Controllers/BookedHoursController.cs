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
    public class BookedHoursController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookedHoursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BookedHours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookedHour>>> GetBookedHours()
        {
          if (_context.BookedHours == null)
          {
              return NotFound();
          }
            return await _context.BookedHours.ToListAsync();
        }

        // GET: api/BookedHours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookedHour>> GetBookedHour(int id)
        {
          if (_context.BookedHours == null)
          {
              return NotFound();
          }
            var bookedHour = await _context.BookedHours.FindAsync(id);

            if (bookedHour == null)
            {
                return NotFound();
            }

            return bookedHour;
        }

        // PUT: api/BookedHours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookedHour(int id, BookedHour bookedHour)
        {
            if (id != bookedHour.BookedHourId)
            {
                return BadRequest();
            }

            _context.Entry(bookedHour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookedHourExists(id))
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

        // POST: api/BookedHours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookedHour>> PostBookedHour(BookedHour bookedHour)
        {
          if (_context.BookedHours == null)
          {
              return Problem("Entity set 'ApplicationDbContext.BookedHours'  is null.");
          }
            _context.BookedHours.Add(bookedHour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookedHour", new { id = bookedHour.BookedHourId }, bookedHour);
        }

        // DELETE: api/BookedHours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookedHour(int id)
        {
            if (_context.BookedHours == null)
            {
                return NotFound();
            }
            var bookedHour = await _context.BookedHours.FindAsync(id);
            if (bookedHour == null)
            {
                return NotFound();
            }

            _context.BookedHours.Remove(bookedHour);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("DateTime{date}/seatId{seatId}")]
        public async Task<ActionResult<List<BookedHour>>> getBookedHoursByDateAndSeatId(DateTime date, int seatId)
        {
            if (_context.BookedHours == null)
            {
                return NotFound();
            }
            var BookedHours =
                 await _context.BookedHours
                .Where(elem => elem.HourForBooking.Date.Date == date.Date && elem.HourForBooking.SeatId == seatId).ToListAsync();

            if (BookedHours == null)
            {
                return NotFound();
            }

            return BookedHours;
        }
        private bool BookedHourExists(int id)
        {
            return (_context.BookedHours?.Any(e => e.BookedHourId == id)).GetValueOrDefault();
        }
    }
}
