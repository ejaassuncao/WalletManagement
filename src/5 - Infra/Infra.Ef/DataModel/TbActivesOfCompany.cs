using Domain.Core.Model.Enumerables;
using Infra.Ef.DataModel.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Ef.DataModel
{
    [Table("tb_actives_company")]
    [Comment("sufix: aoc")]
    public partial class TbActivesOfCompany : TbBase
    {
        [Key]
        [Column("aoc_id")]
        public Guid Id { get; set; }

        [Required]
        [Column("aoc_amount")]
        public int Amount { get; set; }

        [Required]
        [Column("aoc_unit_cost")]
        [Precision(18, 2)]
        public decimal UnitCost { get; set; }

        [Required]
        [Column("aoc_date_buy")]
        public DateTime DateBuy { get; set; }

        [Required]
        [Column("aoc_operation")]
        public EnumOperationWallet Operation { get; set; }

        [ForeignKey("act_id")]
        public TbActive Active { get; set; } = new TbActive();

        [ForeignKey("usu_id")]
        public TbUser User { get; set; } = new TbUser();

        [ForeignKey("bkr_id")]
        public TbBroker Broker { get; set; } = new TbBroker();

    }
}
