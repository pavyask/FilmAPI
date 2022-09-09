using FilmAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly DataContext _context;

        public FilmController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Film>>> GetFilms()
        {
            return Ok(await _context.Film.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Film>> GetFilm(int id)
        {
            var film = await _context.Film.FindAsync(id);
            if (film == null)
                return NotFound("Film not found");

            return Ok(film);
        }

        [HttpPost]
        public async Task<ActionResult<List<Film>>> AddFilm(Film film)
        {
            _context.Film.Add(film);
            await _context.SaveChangesAsync();

            return Ok(await _context.Film.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Film>>> UpdateFilm(Film request)
        {
            var dbFilm = await _context.Film.FindAsync(request.Id);
            if (dbFilm == null)
                return NotFound("There is no film with such id");

            dbFilm.Year = request.Year;
            dbFilm.Title = request.Title;
            dbFilm.Rating = request.Rating;

            await _context.SaveChangesAsync();

            return Ok(await _context.Film.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Film>> DeleteFilm(int id)
        {
            var dbFilm = await _context.Film.FindAsync(id);
            if (dbFilm == null)
                return NotFound("There is no film with such id");

            _context.Film.Remove(dbFilm);
            await _context.SaveChangesAsync();

            return Ok(await _context.Film.ToListAsync());
        }

    }
}
