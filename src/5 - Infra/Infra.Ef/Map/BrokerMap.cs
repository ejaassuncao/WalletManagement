using Domain.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Ef.Map
{
    public class BrokerMap : IEntityTypeConfiguration<Broker>
    {
        public void Configure(EntityTypeBuilder<Broker> builder)
        {
            builder.ToTable("Broker");

            builder.HasKey(c => c.Id)
                .HasName("bkr_id");

            builder.Property(c => c.RazaoSocial)
                .HasColumnName("bkr_razaosocial")
                .HasMaxLength(60);

            builder.Property(c => c.NomeFantasia)
                .HasColumnName("bkr_nomefantasia")
                .HasMaxLength(60);

            builder.Property(c => c.CNPJ)
                 .HasColumnName("bkr_cnpj")
                 .HasMaxLength(15);
        }
    }
}