using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.DataModel;

/// <summary>
/// abbreviation: sct
/// Description: table sector
/// </summary>
[Table("tb_sector")]
public partial class TbSector
{
    /// <summary>
    /// pk table
    /// </summary>
    [Key]
    [Column("sct_Id")]
    public Guid SctId { get; set; }

    /// <summary>
    /// sector name
    /// </summary>
    [Required]
    [Column("sct_name")]
    [StringLength(60)]
    public string SctName { get; set; }

    [Column("sct_DCreated")]
    public DateTime SctDcreated { get; set; }

    public DateTime LastUpdate { get; set; }

    [Column("CIdUserCreated")]
    public string CidUserCreated { get; set; }

    [Column("CIdUserLastUpdate")]
    public string CidUserLastUpdate { get; set; }

    public byte Enabled { get; set; }
}
