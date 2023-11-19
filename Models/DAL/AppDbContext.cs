namespace EntityFrameworkWebAPI.Models.DAL
{
    using Models.Domains;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;


    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        // Model & Relation Mapping:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // must have this line first, else you will end up getting the error (The entity type 'IdentityUserLogin<string>' requires a primary key to be defined. If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating')
            base.OnModelCreating(modelBuilder);


            #region Show - Booking's (1-n) relationship:
            modelBuilder.Entity<Booking>()
            .HasOne(op => op.Show)
            .WithMany(au => au.Bookings)
            .HasForeignKey(op => op.ShowId);
            #endregion

            #region Movie - Show's (1-n) relationship:
            modelBuilder.Entity<Show>()
            .HasOne(op => op.Movie)
            .WithMany(au => au.Shows)
            .HasForeignKey(op => op.MovieId);
            #endregion


            #region Booking - FoodDrink's (n-n) relationship:
            modelBuilder.Entity<OrderedItem>()
                .HasKey(rr => new { rr.BookingId, rr.FoodDrinkId });

            modelBuilder.Entity<OrderedItem>()
                .HasOne(rr => rr.Booking)
                .WithMany(r => r.OrderedItems)
                .HasForeignKey(rr => rr.BookingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderedItem>()
                .HasOne(rr => rr.FoodDrink)
                .WithMany(res => res.OrderedItems)
                .HasForeignKey(rr => rr.FoodDrinkId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion






            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6)); // remove first 6 character
                }
            }
        }


        // Users , it can be ApplicationUser in your project!
        public DbSet<User> Users { get; set; } // "Users" will be the name of SQL table
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Show> Shows { get; set; }
        //public DbSet<Ticket> Tickets { get; set; }
        public DbSet<FoodDrink> FoodDrinks { get; set; }
        public DbSet<OrderedItem> OrderedItems { get; set; }
        public DbSet<Booking> Bookings { get; set; }


    }
}
