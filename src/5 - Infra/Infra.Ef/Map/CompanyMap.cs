using Domain.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Ef.Map
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");

            builder.HasKey(c => c.Id)
                .HasName("cny_id");

            builder.Property(c => c.Name)
                .HasColumnName("cny_name")
                .HasMaxLength(60);

            builder.Property(c => c.CNPJ)
                 .HasColumnName("cny_cnpj")
                 .HasMaxLength(15);

            builder.HasOne<Sector>().WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
