using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace kursovayK.models
{
    public class Auditorium
    {
        [Key]
        public int AuditoriumId {  get; set; }

        public string Name { get; set; }
        public int AmountSeats { get; set; }
        [JsonIgnore]
        public List<Seat>? Seats { get; set; }
    }
}
