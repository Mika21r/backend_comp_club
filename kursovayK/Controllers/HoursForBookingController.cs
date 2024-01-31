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
    public class HoursForBookingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HoursForBookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HoursForBooking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HourForBooking>>> GetHoursForBooking()
        {
          if (_context.HoursForBooking == null)
          {
              return NotFound();
          }
            return await _context.HoursForBooking.ToListAsync();
        }

        // GET: api/HoursForBooking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HourForBooking>> GetHourForBooking(int id)
        {
          if (_context.HoursForBooking == null)
          {
              return NotFound();
          }
            var hourForBooking = await _context.HoursForBooking.FindAsync(id);

            if (hourForBooking == null)
            {
                return NotFound();
            }

            return hourForBooking;
        }

        // PUT: api/HoursForBooking/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHourForBooking(int id, HourForBooking hourForBooking)
        {
            if (id != hourForBooking.HourForBookingId)
            {
                return BadRequest();
            }

            _context.Entry(hourForBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HourForBookingExists(id))
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

        // POST: api/HoursForBooking
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HourForBooking>> PostHourForBooking(HourForBooking hourForBooking)
        {
          if (_context.HoursForBooking == null)
          {
              return Problem("Entity set 'ApplicationDbContext.HoursForBooking'  is null.");
          }
            _context.HoursForBooking.Add(hourForBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHourForBooking", new { id = hourForBooking.HourForBookingId }, hourForBooking);
        }

        // DELETE: api/HoursForBooking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHourForBooking(int id)
        {
            if (_context.HoursForBooking == null)
            {
                return NotFound();
            }
            var hourForBooking = await _context.HoursForBooking.FindAsync(id);
            if (hourForBooking == null)
            {
                return NotFound();
            }

            _context.HoursForBooking.Remove(hourForBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("DateTime{date}/seatId{seatId}")]
        public async Task<ActionResult<List<HourForBooking>>> GetHoursForBookingByDateAndSeatId(DateTime date, int seatId)
        {
            if (_context.HoursForBooking == null)
            {
                return NotFound();
            }
            var HoursForBooking =
                 await _context.HoursForBooking
                .Where(elem => elem.Date.Date == date.Date && elem.SeatId == seatId).ToListAsync();

            if (HoursForBooking == null)
            {
                return NotFound();
            }

            return HoursForBooking;
        }
        private bool HourForBookingExists(int id)
        {
            return (_context.HoursForBooking?.Any(e => e.HourForBookingId == id)).GetValueOrDefault();
        }
    }
}
