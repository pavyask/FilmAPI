﻿namespace FilmAPI.DTO.Film
{
    public class AddFilmDto
    {
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        public float Rating { get; set; }
    }
}
