using Infra.Ef.DataModel.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Ef.DataModel
{
    [Table("tb_company")]
    [Comment("sufix: cpy")]
    public class TbCompany : TbBase
    {
        [Key]
        [Column("cpy_id")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(120)]
        [Column("cpy_name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(18)]
        [Column("cpy_cnpj")]
        public string CNPJ { get; set; } = string.Empty;

        [Column("sct_id")]
        [ForeignKey("TbSector")]
        public Guid? SetorId { get; set; }
        public TbSector? Setor { get; set; }

        public Collection<TbActive>? Actives { get; set; }
    }
}
