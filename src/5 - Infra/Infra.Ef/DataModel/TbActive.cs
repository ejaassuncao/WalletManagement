using Domain.Core.Model.Enumerables;
using Infra.Ef.DataModel.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Ef.DataModel
{

    [Table("tb_actives")]
    [Comment("sufix: act")]
    public class TbActive : TbBase //,IEntityTypeConfiguration<TbActive>
    {
        [Key]
        [Column("act_id")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        [Column("act_ticker")]
        [Comment("Name Ticker")]
        public string Ticker { get; set; } = string.Empty;

        [Column("act_price")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required]
        [Column("act_category")]
        public EnumCategory Category { get; set; }


        [Column("cpy_id")]
        [ForeignKey("TbCompany")]
        public Guid? CompanyId { get; set; }
        public TbCompany? Company { get; set; }


        //depois poderemos brincar com o mapeamento nesse tipo
        //public void Configure(EntityTypeBuilder<TbActive> builder)
        //{
        //    var obj = builder.ToTable("tb_actives", "dbo", (t) =>
        //    {
        //        t.HasComment("sufix: act");
        //    });


        //    builder.HasKey(c => c.Id)
        //           .HasName("act_id");

        //    builder.Property(c => c.Ticker)
        //     .HasColumnName("act_ticker")
        //     .HasMaxLength(20)
        //     .HasComment("Name Ticker").IsRequired()
        //     .HasColumnType("varchar2");

        //    builder.Property(c => c.Price)
        //     .HasColumnName("act_price")
        //     .HasPrecision(18, 2)
        //     .HasComment("Price Active");

        //    builder.Property(c => c.Category)
        //     .HasColumnName("act_category")
        //     .HasComment("Category Active")
        //     .IsRequired();

        //    builder.HasOne(c => c.Company)
        //         .WithMany(cp => cp.Actives)
        //        .HasForeignKey(c => c.CompanyId)
        //        .HasConstraintName("cpy_id")
        //        .HasPrincipalKey(cp => cp.Id)
        //        .OnDelete(DeleteBehavior.NoAction);


        //    /// Columns communs. I will be able to map common properties in the base class

        //    builder.Property(c => c.Enabled)
        //       .HasColumnName("act_enabled")
        //       .HasComment("register enable or active")
        //       .HasDefaultValue(EnumEnabled.Enabled)
        //       .IsRequired();

        //    builder.Property(c => c.Dcreated)
        //       .HasColumnName("act_d_created")
        //       .HasComment("date of created register")
        //       .HasDefaultValue(DateTime.Now)
        //       .IsRequired();

        //    builder.Property(c => c.UserCreated)
        //       .HasColumnName("act_user_created")
        //       .HasComment("user created register")
        //       .IsRequired();
        //}
    }
}
