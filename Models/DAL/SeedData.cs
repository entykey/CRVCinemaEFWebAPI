namespace EntityFrameworkWebAPI.Models.DAL
{
    using Models.Domains;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            // https://stackoverflow.com/questions/52487989/cannot-resolve-scoped-service-microsoft-aspnetcore-identity-usermanager1ident
            using (var scope = app.ApplicationServices.CreateScope())
            {
                // Resolve ASP .NET Core Identity with DI help
                var userManager = (UserManager<User>)scope.ServiceProvider.GetService(typeof(UserManager<User>));
                var roleManager = (RoleManager<IdentityRole>)scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>));

                //var roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();

                var dbContext = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    dbContext.Database.Migrate();
                }

                if (!dbContext.Users.Any())
                {
                    // Create the default admin user                    

                    // Check if the "Admin" role exists, and create it if not
                    if (!roleManager.RoleExistsAsync("Admin").Result)
                    {
                        var adminRole = new IdentityRole("Admin");
                        roleManager.CreateAsync(adminRole).Wait();
                    }

                    // Check if the "Staff" role exists, and create it if not
                    if (!roleManager.RoleExistsAsync("Staff").Result)
                    {
                        var staffRole = new IdentityRole("Staff");
                        roleManager.CreateAsync(staffRole).Wait();
                    }

                    // Create the default admin user
                    var adminUser = new User
                    {
                        UserName = "admin",
                        Email = "admin@example.com",
                        FullName = "Quản lý",
                        DateJoined = DateTimeOffset.Now,
                        Country = "Vietnam",
                        // Add other properties as needed
                    };

                    // Create the admin user with the default password "Abc@123"
                    var result = userManager.CreateAsync(adminUser, "Abc@123").Result;

                    if (result.Succeeded)
                    {
                        // Assign the "Admin" role to the admin user
                        userManager.AddToRoleAsync(adminUser, "Admin").Wait();
                    }

                    // Create the staff user
                    var staffUser = new User
                    {
                        UserName = "staff01",
                        Email = "staff@example.com",
                        FullName = "Nhân viên",
                        DateJoined = DateTimeOffset.Now,
                        Country = "Vietnam",
                        // Add other properties as needed
                    };

                    // Create the admin user with the default password "Abc@123"
                    var staffAccountresult = userManager.CreateAsync(staffUser, "Abc@123").Result;

                    if (staffAccountresult.Succeeded)
                    {
                        // Assign the "Admin" role to the admin user
                        userManager.AddToRoleAsync(adminUser, "Staff").Wait();
                    }

                    // Save changes to the database
                    dbContext.SaveChanges();
                }

                // seed RoomType & Room
                if (!dbContext.Movies.Any())
                {

                    dbContext.Movies.AddRange(
                        new Movie
                        {
                            MovieId = "6d3fdce6-8d34-43af-aee2-1f007d870d73",
                            Title = "The Shawshank Redemption",
                            Description = "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.",
                            Director = "Frank Darabont",
                        },
                        new Movie
                        {
                            //MovieId = "3ec3a6dd-4f5d-415d-be92-9f113d50f755",
                            Title = "The Godfather",
                            Description = "Don Vito Corleone, head of a mafia family, decides to hand over his empire to his youngest son Michael. However, his decision unintentionally puts the lives of his loved ones in grave danger.",
                            Director = "Francis Ford Coppola",
                        }
                     );
                    dbContext.Shows.AddRange(
                        new Show
                        {
                            MovieId = "6d3fdce6-8d34-43af-aee2-1f007d870d73",
                            StartTime = DateTime.Now.AddDays(1),
                        }
                    );

                    // Save changes to the database
                    dbContext.SaveChanges();
                }
            }

        }
    }
}
