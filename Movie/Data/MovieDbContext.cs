using Microsoft.EntityFrameworkCore;
using Movie.Models;

namespace Movie.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Recommender> Recommenders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\Local;Database=MovieDb;Trusted_Connection=True;MultipleActiveResultSets=True");
        }
    }
}
