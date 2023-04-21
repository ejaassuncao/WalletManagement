using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Ef.DataModel.Base
{
    public abstract class TbBase
    {
        [Required]
        [Column("enabled")]
        public bool Enabled { get; set; } = true;

        [Required]
        [Column("d_created")]
        public DateTime Dcreated { get; set; } = DateTime.Now;

        [Required]
        [Column("user_created")]
        public int UserCreated { get; set; }

        [Column("last_update")]
        public DateTime? LastUpdate { get; set; }

        [Column("user_last_update")]
        public int? UserLastUpdate { get; set; }
    }
}
