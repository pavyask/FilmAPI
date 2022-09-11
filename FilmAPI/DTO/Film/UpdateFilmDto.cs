namespace FilmAPI.DTO.Film
{
    public class UpdateFilmDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        public float Rating { get; set; }
    }
}
