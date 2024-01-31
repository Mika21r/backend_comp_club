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
    public class SeatsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SeatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Seats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seat>>> GetSeats()
        {
          if (_context.Seats == null)
          {
              return NotFound();
          }
            return await _context.Seats.ToListAsync();
        }

        // GET: api/Seats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seat>> GetSeat(int id)
        {
          if (_context.Seats == null)
          {
              return NotFound();
          }
            var seat = await _context.Seats.FindAsync(id);

            if (seat == null)
            {
                return NotFound();
            }

            return seat;
        }

        // PUT: api/Seats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeat(int id, Seat seat)
        {
            if (id != seat.SeatId)
            {
                return BadRequest();
            }

            _context.Entry(seat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatExists(id))
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

        // POST: api/Seats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Seat>> PostSeat(Seat seat)
        {
          if (_context.Seats == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Seats'  is null.");
          }
            _context.Seats.Add(seat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeat", new { id = seat.SeatId }, seat);
        }

        // DELETE: api/Seats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            if (_context.Seats == null)
            {
                return NotFound();
            }
            var seat = await _context.Seats.FindAsync(id);
            if (seat == null)
            {
                return NotFound();
            }

            _context.Seats.Remove(seat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Seats/all/5
        [HttpGet("GetSeatsByAuditoriumId/{AuditoriumId}")]
        public async Task<ActionResult<List<Seat>>> GetSeatsByAuditoriumId(int AuditoriumId)
        {
            if (_context.Seats == null)
            {
                return NotFound();
            }
            var Seats =
                 await _context.Seats
                .Where(elem => elem.AuditoriumId == AuditoriumId).ToListAsync();

            if (Seats == null)
            {
                return NotFound();
            }

            return Seats;
        }

        private bool SeatExists(int id)
        {
            return (_context.Seats?.Any(e => e.SeatId == id)).GetValueOrDefault();
        }
    }
}
