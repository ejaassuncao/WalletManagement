using Infra.Ef.DataModel.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Ef.DataModel;

/// <summary>
/// abbreviation:  wal
/// Description: tables wallet
/// </summary>
[Table("tb_wallet")]
[Comment("sufix: wal")]
public partial class TbWallet : TbBase
{
    /// <summary>
    /// PK table
    /// </summary>
    [Key]
    [Column("wal_Id")]
    public Guid Id { get; set; }

    /// <summary>
    /// Name wallet
    /// </summary>
    [Required]
    [StringLength(120)]
    [Column("wal_name")]
    public string Name { get; set; } = string.Empty;


    [Column("usu_id")]
    [ForeignKey("TbUser")]
    public Guid? OwnerId { get; set; }
    public TbUser? Owner { get; set; }


    [Column("bkr_id")]
    [ForeignKey("TbBroker")]
    public Guid? BrokerId { get; set; }
    public TbBroker? Broker { get; set; }

}