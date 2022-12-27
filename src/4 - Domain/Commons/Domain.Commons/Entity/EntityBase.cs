using Domain.Commons.Validate;
using System;

namespace Domain.Commons.Entity
{    public abstract class EntityBase
    {
        public static string MSG_ID_IS_MIN_OR_EGUAL_0 = "Id is min or egual 0";

        protected EntityBase() { }

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





