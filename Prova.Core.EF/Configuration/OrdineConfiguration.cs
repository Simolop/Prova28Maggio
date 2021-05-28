using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prova.Core.Model;

namespace Prova.Core.EF
{
    public class OrdineConfiguration : IEntityTypeConfiguration<Ordine>
    {
        public void Configure(EntityTypeBuilder<Ordine> builder)
        {
            builder
                .HasKey(o => o.ID);

            builder
                .HasOne(o => o.Cliente)
                .WithMany(o => o.Ordini)
                .HasForeignKey(o => o.ClienteID);

            builder
                .Property(o => o.DataOrdine)
                .IsRequired();

            builder
                .Property(o => o.CodiceOrdine)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(o => o.CodiceProdotto)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(o => o.Importo);
                
        }
    }
}