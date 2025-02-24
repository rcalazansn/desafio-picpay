using desafio.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace desafio.api.Map
{
    public class TransferenciaMap : IEntityTypeConfiguration<TransferenciaEntity>
    {
        public void Configure(EntityTypeBuilder<TransferenciaEntity> builder)
        {
            builder
                .ToTable("Transferencias");

            builder
                .HasKey(_ => _.Id);

            builder
                .HasOne(t => t.Pagador)
                .WithMany()
                .HasForeignKey(_ => _.PagadorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Transaction_Sender");

            builder
                .Property(t => t.Valor)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder
                .HasOne(t => t.Recebedor)
                .WithMany()
                .HasForeignKey(t => t.RecebedorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Transaction_Reciver");
        }
    }
}
