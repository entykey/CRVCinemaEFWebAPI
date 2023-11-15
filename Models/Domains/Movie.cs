namespace EntityFrameworkWebAPI.Models.Domains
{
    using System.ComponentModel.DataAnnotations;



    public class Movie
    {
        [Key]
        public string MovieId { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = "Untitled";
        public string? Director { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Description { get; set; }
        // Other properties related to movies
        public IList<Show>? Shows { get; set; }
    }
}
