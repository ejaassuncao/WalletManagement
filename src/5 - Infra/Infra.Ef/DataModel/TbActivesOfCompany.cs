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
        [Precision(18, 3)]
        public decimal Amount { get; set; }

        [Required]
        [Column("aoc_unit_cost")]
        [Precision(18, 2)]
        public decimal UnitCost { get; set; }

        [Required]
        [Column("aoc_date_operation")]
        public DateTime DateOperation { get; set; } = DateTime.Now;

        [Required]
        [Column("aoc_operation")]
        public EnumOperationWallet Operation { get; set; }

        [Column("usu_id")]
        [ForeignKey("TbUser")]
        public Guid? UserId { get; set; }
        public TbUser? User { get; set; }


        [Column("bkr_id")]
        [ForeignKey("TbBroker")]
        public Guid? BrokerId { get; set; }
        public TbBroker? Broker { get; set; }


        [Column("wal_Id")]
        [ForeignKey("TbWallet")]
        public Guid? WalletId { get; set; }
        public TbWallet? Wallet { get; set; }


        [Column("act_id")]
        [ForeignKey("TbActive")]
        public Guid? ActiveId { get; set; }
        public TbActive? Active { get; set; }
    }
}
