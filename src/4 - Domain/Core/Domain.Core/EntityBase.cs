using Domain.Core.Validate;
using System;

namespace Domain.Core
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {

        }

        protected EntityBase(int id)
        {
            Id = id;
            ExceptionDomainValidation.When(id <= 0, "Id is min or egual 0");
        }

        public int Id { get; protected set; }   
        public DateTime DCreated { get; protected set; }
        
        public DateTime LastUpdate { get; protected set; }

        public string CIdUserCreated { get; protected set; }

        public string CIdUserLastUpdate { get; protected set; }

        public EnumEnabled Enabled { get; protected set; }
    }

    public enum EnumEnabled : byte
    {
        Disabled = 0,
        Enabled = 1
    }

}





