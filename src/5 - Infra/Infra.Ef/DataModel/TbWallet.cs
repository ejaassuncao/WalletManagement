using Domain.Core.Model;
using Infra.Ef.DataModel.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Ef.DataModel;

/// <summary>
/// abbreviation:  wal
/// Description: tables wallet
/// </summary>
[Table("tb_wallet")]
[Comment("sufix: wal")]
public partial class TbWallet: TbBase
{
    /// <summary>
    /// PK table
    /// </summary>
    [Column("wal_Id")]
    public Guid Id { get; set; }

    /// <summary>
    /// Name wallet
    /// </summary>
    [Required]
    [StringLength(120)]
    [Column("wal_name")]
    public string Name { get; set; } = string.Empty;

    public TbUser Owner { get; set; } = new TbUser();

    public TbBroker Broker { get; set; } = new TbBroker();

    public ICollection<TbActivesOfCompany> Actives { get; set; } = new Collection<TbActivesOfCompany>();
     
}
