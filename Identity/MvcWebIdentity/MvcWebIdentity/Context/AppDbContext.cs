using Microsoft.EntityFrameworkCore;
using MvcWebIdentity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace MvcWebIdentity.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Aluno> Alunos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno()
                {
                    AlunoId = 1,
                    age = 21,
                    Curso = "Eng-Comp",
                    Name = "Biel",
                    Email = "gabriel@gmail.com"
                });
        }

    }
}
