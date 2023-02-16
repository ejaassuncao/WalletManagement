using Domain.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Ef.Map
{
    public class SectorMap : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.ToTable("Sector");

            builder.HasKey(c => c.Id)
                .HasName("sct_id");

            builder.Property(c => c.Name)
                .HasColumnName("sct_name")
                .HasMaxLength(60);
        }
    }
}
