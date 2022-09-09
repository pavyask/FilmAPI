using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private static List<Film> films = new List<Film>
            {
                new Film{Id=1,Title="Interstellar", Year=2014 ,Rating=8.6F},
                new Film{Id=2,Title="The Lord of the Rings: The Fellowship of the Ring", Year=2001 ,Rating=8.8F},
                new Film{Id=3,Title="Inception", Year=2010 ,Rating=8.8F}
            };

        [HttpGet]
        public async Task<ActionResult<List<Film>>> Get()
        {
            return Ok(films);
        }
    }
}
