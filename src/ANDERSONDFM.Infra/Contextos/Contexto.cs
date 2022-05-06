using Microsoft.EntityFrameworkCore;
using ANDERSONDFM.Dominio.Entidades;
using ANDERSONDFM.Infra.Mapeamentos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ANDERSONDFM.Infra.Contextos
{
    public class Contexto : IdentityDbContext
    {
        public Contexto(DbContextOptions options) : base(options)
        { }

        public DbSet<Produtos> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoMap).Assembly);
        }
    }
}
