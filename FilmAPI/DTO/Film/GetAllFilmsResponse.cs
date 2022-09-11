namespace FilmAPI.DTO.Film
{
    public class GetFilmsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
