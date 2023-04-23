using Domain.Core.Model.Enumerables;
using Infra.Ef.DataModel.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Ef.DataModel
{

    [Table("tb_actives")]
    [Comment("sufix: act")]
    public class TbActive : TbBase
    {
        [Key]
        [Column("act_id")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        [Column("act_ticker")]
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
    }
}
