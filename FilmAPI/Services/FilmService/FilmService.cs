using AutoMapper;
using FilmAPI.Data;
using FilmAPI.DTO.Film;
using FilmAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Services.FilmService
{
    public class FilmService : IFilmService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public FilmService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetFilmsDto>>> GetAllFilms()
        {
            var serviceResponse = new ServiceResponse<List<GetFilmsDto>>();

            var films = await _context.Film.ToListAsync();
            serviceResponse.Data = films.Select(f => _mapper.Map<GetFilmsDto>(f)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetFilmDto>> GetFilmByID(int id)
        {
            var serviceResponse = new ServiceResponse<GetFilmDto>();

            var dbFilm = await _context.Film.FindAsync(id);

            if (dbFilm == null)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = "There is no film with such id";
                return serviceResponse;
            }

            serviceResponse.Data = _mapper.Map<GetFilmDto>(dbFilm);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetFilmsDto>>> AddFilm(AddFilmDto filmDto)
        {
            var serviceResponse = new ServiceResponse<List<GetFilmsDto>>();
            var film = _mapper.Map<Film>(filmDto);

            _context.Film.Add(film);
            await _context.SaveChangesAsync();


            var films = await _context.Film.ToListAsync();
            serviceResponse.Data =films.Select(f=>_mapper.Map<GetFilmsDto>(f)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetFilmsDto>>> UpdateFilm(UpdateFilmDto request)
        {
            var serviceResponse = new ServiceResponse<List<GetFilmsDto>>();
            var films = new List<Film>();

            var dbFilm = await _context.Film.FindAsync(request.Id);
            if (dbFilm == null)
            {
                films = await _context.Film.ToListAsync();

                serviceResponse.Data = films.Select(f => _mapper.Map<GetFilmsDto>(f)).ToList();
                serviceResponse.Succes = false;
                serviceResponse.Message = "There is no film with such id";

                return serviceResponse;
            }

            dbFilm.Year = request.Year;
            dbFilm.Title = request.Title;
            dbFilm.Rating = request.Rating;

            await _context.SaveChangesAsync();

            films = await _context.Film.ToListAsync();
            serviceResponse.Data = films.Select(f => _mapper.Map<GetFilmsDto>(f)).ToList();
            return serviceResponse;
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<List<GetFilmsDto>>> DeleteFilmById(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetFilmsDto>>();
            var films = new List<Film>();

            var dbFilm = await _context.Film.FindAsync(id);
            if (dbFilm == null)
            {
                serviceResponse.Data = films.Select(f => _mapper.Map<GetFilmsDto>(f)).ToList();
                serviceResponse.Succes = false;
                serviceResponse.Message = "There is no film with such id";
                return serviceResponse;
            }

            _context.Film.Remove(dbFilm);
            await _context.SaveChangesAsync();

            films = await _context.Film.ToListAsync();
            serviceResponse.Data = films.Select(f => _mapper.Map<GetFilmsDto>(f)).ToList();
            return serviceResponse;
        }
    }
}