using Domain.Core.Model;
using Infra.Ef.Map;
using Microsoft.EntityFrameworkCore;

namespace Infra.Ef.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ActionMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new SectorMap());
            modelBuilder.ApplyConfiguration(new BrokerMap());
        }

        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Broker> Brokers { get; set; }
    }
}
