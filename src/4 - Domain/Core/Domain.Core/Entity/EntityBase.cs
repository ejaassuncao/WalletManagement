using Domain.Commons.Validate;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Commons.Entity
{
    public abstract class EntityBase
    {
        public static string MSG_ID_IS_MIN_OR_EGUAL_0 = "Id is min or egual 0";

        public EntityBase()
        {

        }

        protected EntityBase(Guid? id)
        {            
            Id = id;
            ExceptionDomainValidation.When(id ==null, "Id is min or egual 0");
        }

        public EnumEnabled Enabled { get; protected set; } = EnumEnabled.Enabled;

        public Guid? Id { get; protected set; }

        public DateTime DCreated { get; protected set; } = DateTime.Now;

        public Guid UserCreated { get; protected set; }

        public DateTime? LastUpdate { get; protected set; }

        public Guid UserLastUpdate { get; protected set; }

        public void SetLastUpdate(DateTime lastUpdate)
        {
            LastUpdate = lastUpdate;
        }

        public void SetUserLastUpdate(Guid userLastUpdate)
        {
            UserLastUpdate = userLastUpdate;
        }

        public void SetEnabled(EnumEnabled value)
        {
            Enabled = value;
        }
    }

    public enum EnumEnabled : byte
    {
        Disabled = 0,
        Enabled = 1
    }
}





