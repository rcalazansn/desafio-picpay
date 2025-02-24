using desafio.api.Models;
using Microsoft.EntityFrameworkCore;

namespace desafio.api.Context
{
    public class DesafioPicPayDbContext : DbContext
    {
        public DesafioPicPayDbContext(DbContextOptions<DesafioPicPayDbContext> options)
            : base(options) { }

        public DbSet<TransferenciaEntity> Transferencias { get; set; }
        public DbSet<CarteiraEntity> Carteiras { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DesafioPicPayDbContext).Assembly);
        }
    }
}
