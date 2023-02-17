using System;
using System.Collections.Generic;

namespace Infra.Ef.EntityData;

/// <summary>
/// abbreviation: sct
/// Description: table sector
/// </summary>
public partial class TbSector
{
    /// <summary>
    /// pk table
    /// </summary>
    public Guid SctId { get; set; }

    /// <summary>
    /// sector name
    /// </summary>
    public string SctName { get; set; } = null!;

    public DateTime SctDcreated { get; set; }

    public DateTime LastUpdate { get; set; }

    public string? CidUserCreated { get; set; }

    public string? CidUserLastUpdate { get; set; }

    public byte Enabled { get; set; }
}
