using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace kursovayK.models
{
    public class BookedHour
    {
        [Key]
        public int BookedHourId {  get; set; }
        public int BookingId { get; set; }
        public int HourForBookingId { get; set; }
        [JsonIgnore]
        public virtual Booking? Booking { get; set; }
        [JsonIgnore]
        public virtual HourForBooking? HourForBooking { get; set; }
    }

}
