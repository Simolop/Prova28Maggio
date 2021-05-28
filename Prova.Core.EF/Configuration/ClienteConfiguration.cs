using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prova.Core.Model;

namespace Prova.Core.EF
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .HasKey(c => c.ID);

            builder
                .Property(c => c.CodiceCliente)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(c => c.Cognome)
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}