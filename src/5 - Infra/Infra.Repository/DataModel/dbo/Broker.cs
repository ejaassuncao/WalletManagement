using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.DataModel;

[Table("Broker")]
public partial class Broker
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [Column("bkr_nomefantasia")]
    [StringLength(60)]
    public string BkrNomefantasia { get; set; }

    [Required]
    [Column("bkr_razaosocial")]
    [StringLength(60)]
    public string BkrRazaosocial { get; set; }

    [Required]
    [Column("bkr_cnpj")]
    [StringLength(15)]
    public string BkrCnpj { get; set; }

    [Column("DCreated")]
    public DateTime Dcreated { get; set; }

    public DateTime LastUpdate { get; set; }

    [Required]
    [Column("CIdUserCreated")]
    public string CidUserCreated { get; set; }

    [Required]
    [Column("CIdUserLastUpdate")]
    public string CidUserLastUpdate { get; set; }

    public byte Enabled { get; set; }
}
