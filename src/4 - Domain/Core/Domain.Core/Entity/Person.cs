using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commons.Entity
{
    public class Person :EntityBase
    {
        public Person(Guid userCreated) : base(userCreated)
        {
        }

        public string Nome { get; set; }
    }
}
