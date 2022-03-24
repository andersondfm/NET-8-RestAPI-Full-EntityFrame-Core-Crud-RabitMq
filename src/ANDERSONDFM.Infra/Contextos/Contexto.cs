using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANDERSONDFM.Dominio.Entidades;
using ANDERSONDFM.Infra.Mapeamentos;

namespace ANDERSONDFM.Infra.Contextos
{
    public class Contexto : DbContext
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
