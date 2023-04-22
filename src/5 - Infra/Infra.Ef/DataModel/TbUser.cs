using Infra.Ef.DataModel.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Ef.DataModel
{
    [Table("tb_user")]
    [Comment("sufix: usu")]
    public partial class TbUser : TbBase
    {
        [Key]
        [Column("usu_id")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(60)]
        [Column("usu_login")]
        public string Login { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        [Column("usu_password")]
        public string Password { get; set; } = string.Empty;

    }
}
