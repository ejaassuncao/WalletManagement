namespace Domain.Models.Dto
{
    public class ItemList
    {
        public ItemList()
        {

        }

        public ItemList(string code, string name, string description)
        {
            Code = code;
            Name = name;
            Description = description;
        }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

       // public string NameAndDescription { get { return $"{Name} - {Description}"; } }
    }
}
