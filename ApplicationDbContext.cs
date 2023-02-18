using Microsoft.EntityFrameworkCore;
using WebApi_Alumnos.Models;

namespace WebApi_Alumnos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Alumno> Alumnos { get; set; }

    }
}
