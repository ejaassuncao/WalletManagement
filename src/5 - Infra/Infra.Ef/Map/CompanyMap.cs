using Domain.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Ef.Map
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("cnp_company");
            builder.HasKey(c => c.Id)
                .HasName("cnp_id");

            builder.Property(c => c.Name).HasMaxLength(60);
            builder.Property(c => c.CNPJ).HasMaxLength(15);
        }
    }
}
