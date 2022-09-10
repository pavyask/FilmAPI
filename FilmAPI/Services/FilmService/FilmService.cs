using FilmAPI.Data;
using FilmAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Services.FilmService
{
    public class FilmService : IFilmService
    {
        private readonly DataContext _context;

        public FilmService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Film>>> GetAllFilms()
        {
            var serviceResponse = new ServiceResponse<List<Film>>();

            serviceResponse.Data = await _context.Film.ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<Film>> GetFilmByID(int id)
        {
            var serviceResponse = new ServiceResponse<Film>();

            var dbFilm = await _context.Film.FindAsync(id);

            if (dbFilm == null)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = "There is no film with such id";
                return serviceResponse;
            }

            serviceResponse.Data = dbFilm;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Film>>> AddFilm(Film film)
        {
            var serviceResponse = new ServiceResponse<List<Film>>();

            _context.Film.Add(film);
            await _context.SaveChangesAsync();


            serviceResponse.Data = await _context.Film.ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Film>>> UpdateFilm(Film request)
        {
            var serviceResponse = new ServiceResponse<List<Film>>();
            serviceResponse.Data = await _context.Film.ToListAsync();

            var dbFilm = await _context.Film.FindAsync(request.Id);
            if (dbFilm == null)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = "There is no film with such id";
                return serviceResponse;
            }

            dbFilm.Year = request.Year;
            dbFilm.Title = request.Title;
            dbFilm.Rating = request.Rating;

            await _context.SaveChangesAsync();

            return serviceResponse;
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<List<Film>>> DeleteFilmById(int id)
        {
            var serviceResponse = new ServiceResponse<List<Film>>();

            var dbFilm = await _context.Film.FindAsync(id);
            if (dbFilm == null)
            {
                serviceResponse.Data = await _context.Film.ToListAsync();
                serviceResponse.Succes = false;
                serviceResponse.Message = "There is no film with such id";
                return serviceResponse;
            }

            _context.Film.Remove(dbFilm);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Film.ToListAsync();
            return serviceResponse;
        }
    }
}
