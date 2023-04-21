using Infra.Ef.DataModel.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Ef.DataModel;

/// <summary>
/// abbreviation: sct
/// Description: table sector
/// </summary>
[Table("tb_sector")]
[Comment("sufix: sct")]
public partial class TbSector: TbBase
{
    /// <summary>
    /// pk table
    /// </summary>
    [Key]
    [Column("sct_id")]
    public Guid Id { get; set; }

    /// <summary>
    /// sector name
    /// </summary>
    [Column("sct_name")]
    [StringLength(120)]
    [Required]
    public string Name { get; set; } = null!;
}
