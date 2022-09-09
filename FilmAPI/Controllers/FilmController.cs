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
        public async Task<ActionResult<List<Film>>> GetFilms()
        {
            return Ok(films);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Film>> GetFilm(int id)
        {
            var film = films.Find(x => x.Id == id);
            if (film == null)
                return NotFound("Film not found");

            return Ok(film);
        }

        [HttpPost]
        public async Task<ActionResult<List<Film>>> AddFilm(Film film)
        {
            films.Add(film);
            return Ok(films);
        }

        [HttpPut]
        public async Task<ActionResult<List<Film>>> UpdateFilm(Film film)
        {
            var filmToChange = films.Find(x => x.Id == film.Id);
            if (filmToChange == null)
                return NotFound("There is no film with such id");

            filmToChange.Year = film.Year;
            filmToChange.Title = film.Title;
            filmToChange.Rating = film.Rating;
            return Ok(films);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Film>> DeleteFilm(int id)
        {
            var film = films.Find(x => x.Id == id);
            if (film == null)
                return NotFound("There is no film with such id");

            films.Remove(film);
            return Ok(film);
        }

    }
}
