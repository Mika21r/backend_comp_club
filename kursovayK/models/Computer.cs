using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace kursovayK.models
{
    public class Computer
    {
        [Key]
        public int ComputerId { get; set; }
        public string? Processor { get; set; }
        public string? VideoCard {  get; set; }
        public string? Headphones { get; set; }
        public string? Keyboard { get; set; }
        public string? Mouse { get; set; }
        public string? GamingChair { get; set; }
        [JsonIgnore]
        public List<Seat>? Seats { get; set; }
    }
}
