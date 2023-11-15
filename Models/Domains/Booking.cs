namespace EntityFrameworkWebAPI.Models.Domains
{
    using System.ComponentModel.DataAnnotations;

    public class Booking
    {
        [Key]
        public string BookingId { get; set; } = Guid.NewGuid().ToString();
        public string ShowId { get; set; }
        public string SeatNumber { get; set; }
        public bool? IsBooked { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;

        // Navigation property
        public virtual Show? Show { get; set; }
    }
}
