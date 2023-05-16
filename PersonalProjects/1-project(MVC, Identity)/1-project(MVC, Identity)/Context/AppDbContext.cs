using _1_project_MVC__Identity_.Entities;
using Microsoft.EntityFrameworkCore;

namespace _1_project_MVC__Identity_.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<GameRecord> GameRecords { get; set; }

    }
}
