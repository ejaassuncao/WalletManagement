using Domain.Models.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;

namespace Domain.Models.Settings
{
    public class Settings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public BrApi BrApi { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }

    public class BrApi : IBrApiConfiguration
    {
        public string Token { get; set; }
    }
}
