using Domain.Commons.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Ef.DataModel.Base
{
    public abstract class TbBase
    {
        [Required]
        [Column("enabled")]
        public EnumEnabled Enabled { get; set; } = EnumEnabled.Enabled;

        [Required]
        [Column("d_created")]
        public DateTime Dcreated { get; set; } = DateTime.Now;

        [Required]
        [Column("user_created")]
        public Guid UserCreated { get; set; }

        [Column("last_update")]
        public DateTime? LastUpdate { get; set; }

        [Column("user_last_update")]
        public Guid? UserLastUpdate { get; set; }
    }
}
