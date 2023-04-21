using Infra.Ef.DataModel.Base;
using Microsoft.EntityFrameworkCore;
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

        [ForeignKey("sct_id")]
        public TbSector Setor { get; set; } = new TbSector();
    }
}
