using Domain.Commons.Entity;
using System;

namespace Domain.Core.Model
{
    public sealed class Sector : EntityBase
    {
        public string Name { get; init; }

        public Sector(string name)
        {
            Name = name;
        }

        public Sector(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}
