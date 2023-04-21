using Infra.Ef.DataModel.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Ef.DataModel
{
    [Table("tb_broker")]
    [Comment("sufix: bkr")]
    public partial class TbBroker : TbBase
    {
        [Key]
        [Column("bkr_id")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(120)]
        [Column("bkr_fantasy_name")]
        public string FantasyName { get; init; } = string.Empty;

        [Required]
        [StringLength(120)]
        [Column("bkr_corporate_name")]
        public string CorporateName { get; init; } = string.Empty;

        [Required]
        [StringLength(18)]
        [Column("bkr_cnpj")]
        public string CNPJ { get; init; } = string.Empty;
    }
}
