using FilmAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Film> Film { get; set; }
    }
}
