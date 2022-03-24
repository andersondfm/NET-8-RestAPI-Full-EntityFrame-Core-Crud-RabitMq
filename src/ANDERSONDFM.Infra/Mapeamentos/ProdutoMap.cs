using ANDERSONDFM.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ANDERSONDFM.Infra.Mapeamentos
{
    public class ProdutoMap : IEntityTypeConfiguration<Produtos>
    {
        public void Configure(EntityTypeBuilder<Produtos> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnName("Nome").HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.DataInclusao).HasColumnName("DataInclusao").HasColumnType("datetime2(7)").IsRequired();
            builder.Property(x => x.UsuarioInclusao).HasColumnName("UsuarioInclusao").HasColumnType("varchar(50)").IsRequired();
        }
    }
}
