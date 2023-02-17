using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.DataModel;

/// <summary>
/// abbreviation:  wal
/// Description: tables wallet
/// </summary>
[Table("tb_wallet")]
public partial class TbWallet
{
    /// <summary>
    /// PK table
    /// </summary>
    [Key]
    [Column("wal_Id")]
    public Guid WalId { get; set; }

    /// <summary>
    /// Name wallet
    /// </summary>
    [Required]
    [Column("wal_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string WalName { get; set; }

    [Column("wal_new")]
    [StringLength(50)]
    [Unicode(false)]
    public string WalNew { get; set; }
}
