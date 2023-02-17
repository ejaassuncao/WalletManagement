using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infra.Ef.EntityData;

/// <summary>
/// abbreviation:  wal
/// Description: tables wallet
/// </summary>
[Keyless]
[Table("tb_wallet")]
public partial class TbWallet
{
    /// <summary>
    /// PK table
    /// </summary>
    [Column("wal_Id")]
    public Guid WalId { get; set; }

    /// <summary>
    /// Name wallet
    /// </summary>
    [Column("wal_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string WalName { get; set; } = null!;
}
