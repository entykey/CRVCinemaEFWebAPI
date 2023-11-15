namespace EntityFrameworkWebAPI.Models.Domains
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class Show
    {
        [Key]
        public string ShowId { get; set; } = Guid.NewGuid().ToString();
        public string MovieId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        // Other properties related to movie shows
        [JsonIgnore]
        public ICollection<Booking>? Bookings { get; set; }
        public Movie? Movie { get; set; }
    }
}
