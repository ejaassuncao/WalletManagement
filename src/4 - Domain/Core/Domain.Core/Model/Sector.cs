using Domain.Commons.Entity;

namespace Domain.Core.Model
{
    public sealed class Sector : EntityBase
    {
        public string Name { get; set; }

        public Sector(string name)
        {
            Name = name;
        }

        public Sector(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
