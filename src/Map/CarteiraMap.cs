using desafio.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace desafio.api.Map
{
    public class CarteiraMap : IEntityTypeConfiguration<CarteiraEntity>
    {
        public void Configure(EntityTypeBuilder<CarteiraEntity> builder)
        {
            builder
                .ToTable("Carteiras");

            builder
                .HasKey(_ => _.Id);

            builder
              .Property(_ => _.CpfCnpj)
              .IsRequired()
              .HasColumnType("varchar(14)");

            builder
                .HasIndex(_ => new { _.CpfCnpj, _.Email })
                .IsUnique();

            builder
                .Property(_ => _.SaldoConta)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder
                .Property(_ => _.TipoUsuario)
                .IsRequired()
                .HasConversion<string>();
        }
    }
}
