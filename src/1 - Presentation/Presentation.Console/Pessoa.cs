using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Console
{
    public class Pessoa
    {
        [Column("wal_Id")]
        public int PesId { get; set; }

        [Column("wal_Nome")]
        public int PesNome { get; set; }
    }
}
