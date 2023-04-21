using Infra.Ef.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infra.Ef.Context;

public partial class AppDBContext : DbContext
{
    public AppDBContext()
    {
    }

    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbActive> TbActives { get; set; }

    public virtual DbSet<TbCompany> TbCompanys { get; set; }

    public virtual DbSet<TbSector> TbSectors { get; set; }

     public virtual DbSet<TbBroker> TbBrokers { get; set; }

     public virtual DbSet<TbUser> TbUsers { get; set; }

     public virtual DbSet<TbActivesOfCompany> TbActivesOfCompanys { get; set; }

     public virtual DbSet<TbWallet> TbWallets { get; set; }  

}
