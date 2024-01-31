using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace kursovayK.models
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<Auditorium> Auditoriums { get; set; }
        public DbSet<BookedHour> BookedHours { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<HourForBooking> HoursForBooking { get; set; }
        public DbSet<Seat> Seats { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HourForBooking>().HasIndex(elem => new { elem.Date, elem.SeatId, elem.Hour }).IsUnique();
            builder.Entity<BookedHour>().HasIndex(elem => new { elem.HourForBookingId }).IsUnique();
            
            base.OnModelCreating(builder);
        }
    }
}
