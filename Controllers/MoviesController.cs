namespace EntityFrameworkWebAPI.Controllers
{
    using EntityFrameworkWebAPI.Models.DAL;
    using Microsoft.AspNetCore.Mvc;


    [ApiController]
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        private readonly AppDbContext _dbContext;
        public MoviesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = _dbContext.Movies.ToList();
            return Ok(res);
        }
    }
}
