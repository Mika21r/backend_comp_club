using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace kursovayK.models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        
        public int ClientId { get; set; }
        public DateTime DateBooking { get; set; }
        public int AmountHours { get; set; }
        public int Cost { get; set; }

        [JsonIgnore]
        public virtual Client? Client { get; set; }

        [JsonIgnore]
        public List<BookedHour>? BookedHours { get; set; }
    }
}
