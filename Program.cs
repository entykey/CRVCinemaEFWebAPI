using EntityFrameworkWebAPI.Models.DAL;
using EntityFrameworkWebAPI.Models.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
    options.SupportedCultures = new List<System.Globalization.CultureInfo> { new System.Globalization.CultureInfo("en-US") };
    options.SupportedUICultures = new List<System.Globalization.CultureInfo> { new System.Globalization.CultureInfo("en-US") };
});


#region AppDbContext & Identity
var connectionString = builder.Configuration.GetConnectionString("MSSQLConnection") ?? throw new InvalidOperationException("Connection string 'MSSQLConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// to use 'AddDefaultIdentity': install package 'Microsoft.AspNetCore.Identity.UI' !!! NET 7
builder.Services.AddDefaultIdentity<User>()
    //.AddUserManager<CustomUserManager>()    // use the implemented CustomUserManager with password hashing algorithm replaced by SHA256
    //.AddSignInManager<CustomSignInManager<ApplicationUser>>()   // only for MVC projects with cookie auth to use SHA256 password hashing algorithm
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Seed default admin account:
SeedData.EnsurePopulated(app);

app.MapControllers();

app.Run();
