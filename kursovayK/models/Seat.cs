using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace kursovayK.models
{
    public class Seat
    {
        [Key]
        public int SeatId {  get; set; }

        public int ComputerId {  get; set; }

        public int AuditoriumId { get; set; }

        [JsonIgnore]
        public virtual Auditorium? Auditorium { get; set; }
        [JsonIgnore]
        public virtual Computer? Computer { get; set; }
        [JsonIgnore]
        public List<HourForBooking>? HoursForBooking { get; set; }
    }
}
