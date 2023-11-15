namespace EntityFrameworkWebAPI.Models.Domains
{
    using System.ComponentModel.DataAnnotations;


    public class OrderedItem
    {
        //[Key]
        //public string OrderedItemId { get; set; } = Guid.NewGuid().ToString();
        public string TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public string FoodDrinkId { get; set; }
        public FoodDrink? FoodDrink { get; set; }
        public int? Quantity { get; set; } = 1;

    }
}
