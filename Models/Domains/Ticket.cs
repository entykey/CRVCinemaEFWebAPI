namespace EntityFrameworkWebAPI.Models.Domains
{
    using System.ComponentModel.DataAnnotations;



    public class Ticket
    {
        [Key]
        public string TicketId { get; set; } = Guid.NewGuid().ToString();
        public string ShowId { get; set; }
        public string SeatNumber { get; set; }
        public bool IsBooked { get; set; }

        // Additional details directly in the Ticket for simplicity
        public DateTime? DatePrinted { get; set; } = DateTime.Now;
        public List<OrderedItem>? OrderedItems { get; set; }
    }

}
