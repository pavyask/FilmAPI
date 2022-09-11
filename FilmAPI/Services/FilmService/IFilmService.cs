using FilmAPI.DTO.Film;
using FilmAPI.Models;

namespace FilmAPI.Services.FilmService
{
    public interface IFilmService
    {
        Task<ServiceResponse<List<GetFilmsDto>>> GetAllFilms();
        Task<ServiceResponse<Film>> GetFilmByID(int id);
        Task<ServiceResponse<List<GetFilmsDto>>> AddFilm(AddFilmDto filmDto);
        Task<ServiceResponse<List<GetFilmsDto>>> UpdateFilm(Film film);
        Task<ServiceResponse<List<GetFilmsDto>>> DeleteFilmById(int id);
    }
}
