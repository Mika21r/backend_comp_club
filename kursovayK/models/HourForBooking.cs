using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace kursovayK.models
{
    public class HourForBooking
    {
        [Key]
        public int HourForBookingId { get; set; }
        public int SeatId { get; set; }
        public DateTime Date {  get; set; }
        public string? Hour {  get; set; }
        public int Cost { get; set; }
        [JsonIgnore]
        public virtual Seat? Seat { get; set; }
        [JsonIgnore]
        public virtual BookedHour? BookedHour { get; set; }
    }
}
