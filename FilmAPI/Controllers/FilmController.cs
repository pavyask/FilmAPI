using FilmAPI.Data;
using FilmAPI.Models;
using FilmAPI.Services.FilmService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Film>>>> GetFilms()
        {
            return Ok(await _filmService.GetAllFilms());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Film>>> GetFilm(int id)
        {
            var serviceResponse = await _filmService.GetFilmByID(id);
            if (serviceResponse.Succes == false)
                return NotFound(serviceResponse.Message);

            return Ok(serviceResponse.Data);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Film>>>> AddFilm(Film film)
        {
            return Ok(await _filmService.AddFilm(film));
        }

        [HttpPut]
        public async Task<ActionResult<List<Film>>> UpdateFilm(Film film)
        {
            var serviceResponse = await _filmService.UpdateFilm(film);
            if (serviceResponse.Succes == false)
                return NotFound(serviceResponse.Message);

            return Ok(serviceResponse.Data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Film>>> DeleteFilm(int id)
        {
            var serviceResponse = await _filmService.DeleteFilmById(id);
            if (serviceResponse.Succes == false)
                return NotFound(serviceResponse.Message);

            return Ok(serviceResponse.Data);
        }
    }
}