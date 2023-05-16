using Microsoft.EntityFrameworkCore;
using MvcIdentity.Entities;


namespace MvcIdentity.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<GameRecord> GameRecords { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GameRecord>().HasData(
                new GameRecord()
                {
                    MatchId = 1,
                    Against = "Computer",
                    GameName = "Jokenpo",
                    WinOrLoose = true,
                    Duration = TimeSpan.FromMinutes(5),
                    TimeRecord = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                }
        );
        }

    }
}
