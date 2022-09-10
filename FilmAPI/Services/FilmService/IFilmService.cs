using FilmAPI.Models;

namespace FilmAPI.Services.FilmService
{
    public interface IFilmService
    {
        Task<ServiceResponse<List<Film>>> GetAllFilms();
        Task<ServiceResponse<Film>> GetFilmByID(int id);
        Task<ServiceResponse<List<Film>>> AddFilm(Film film);
        Task<ServiceResponse<List<Film>>> UpdateFilm(Film film);
        Task<ServiceResponse<List<Film>>> DeleteFilmById(int id);
    }
}
