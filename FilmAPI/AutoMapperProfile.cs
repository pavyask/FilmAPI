using AutoMapper;
using FilmAPI.DTO.Film;
using FilmAPI.Models;

namespace FilmAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Film, GetFilmsDto>();
            CreateMap<AddFilmDto, Film>();
        }
    }
}
