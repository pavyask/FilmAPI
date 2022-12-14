using FilmAPI.Data;
using FilmAPI.DTO.Film;
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
        public async Task<ActionResult<ServiceResponse<List<GetFilmsDto>>>> GetFilms()
        {
            return Ok(await _filmService.GetAllFilms());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetFilmDto>>> GetFilm(int id)
        {
            var serviceResponse = await _filmService.GetFilmByID(id);
            if (serviceResponse.Succes == false)
                return NotFound(serviceResponse.Message);

            return Ok(serviceResponse.Data);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetFilmsDto>>>> AddFilm(AddFilmDto filmDto)
        {
            return Ok(await _filmService.AddFilm(filmDto));
        }

        [HttpPut]
        public async Task<ActionResult<List<GetFilmsDto>>> UpdateFilm(UpdateFilmDto filmDto)
        {
            var serviceResponse = await _filmService.UpdateFilm(filmDto);
            if (serviceResponse.Succes == false)
                return NotFound(serviceResponse.Message);

            return Ok(serviceResponse.Data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<GetFilmsDto>>> DeleteFilm(int id)
        {
            var serviceResponse = await _filmService.DeleteFilmById(id);
            if (serviceResponse.Succes == false)
                return NotFound(serviceResponse.Message);

            return Ok(serviceResponse.Data);
        }
    }
}