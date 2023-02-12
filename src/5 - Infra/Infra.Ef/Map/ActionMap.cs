using Domain.Core.Model.Actives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Ef.Map
{
    public class ActionMap : IEntityTypeConfiguration<AbstractActives>
    {
        public void Configure(EntityTypeBuilder<AbstractActives> builder)
        {
            builder.ToTable("Active");
            builder.HasKey(c => c.Id)
                .HasName("act_id");

            builder.Property(c => c.Ticker)
                .HasColumnName("act_ticker");

            builder.Property(c => c.CIdUserCreated)
               .HasColumnName("act_cidusercreated");

            builder.Property(c => c.CIdUserLastUpdate)
              .HasColumnName("act_ciduserlastupdate");          

            builder.Property(c => c.TypeActives)
              .HasColumnName("act_typeactives");

            builder.Property(c => c.Enabled)
             .HasColumnName("act_enabled");

            builder.Property(c => c.DCreated)
             .HasColumnName("act_dcreated");


            builder.Property(c => c.LastUpdate)
             .HasColumnName("act_lastupdate");

            builder.Property(c => c.Counting)
            .HasColumnName("act_counting");

            builder.Property(c => c.Counting)
            .HasColumnName("act_counting");
            
            
            builder.HasOne(c => c.Company)
                .WithMany()
                .HasConstraintName("cpn_id")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
