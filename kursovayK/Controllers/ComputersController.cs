using kursovayK.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kursovayK.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace kursovayK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComputersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Computers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Computer>>> GetBookings()
        {
            if (_context.Computers == null)
            {
                return NotFound();
            }
            return await _context.Computers.ToListAsync();
        }

        // GET: api/Computers/5
        [HttpGet("{ComputerId}")]
        public async Task<ActionResult<Computer>> getComputerByComputerId(int ComputerId)
        {
            if (_context.Computers == null)
            {
                return NotFound();
            }
            var computer = await _context.Computers.FindAsync(ComputerId);

            if (computer == null)
            {
                return NotFound();
            }

            return computer;
        }

       
    }
}
