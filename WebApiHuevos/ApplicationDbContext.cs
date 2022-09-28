using Microsoft.EntityFrameworkCore;
using WebApiHuevos.Entidades;

namespace WebApiHuevos
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Encargado> Encargados { get; set; }
        public DbSet<Huevo> Huevos { get; set; }
}
}
