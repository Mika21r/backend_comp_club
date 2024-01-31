using System.ComponentModel.DataAnnotations;

namespace kursovayK.models
{
    public class Client
    {
        [Key]
        public int ClietnId { get; set; }
        public string? FIO { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumbee { get; set; }
        public List<Booking>? Bookings { get; set; }
    }
}
