using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class LeasingDbContext : DbContext
    {
        public LeasingDbContext(DbContextOptions<LeasingDbContext> options) : base(options) //DbContextOptions ce db este folosita si detalii de conectare ca sunt primite ca parametrii din Startup.cs prin DependencyInjection
        {

        }

        public DbSet<AssetHierarchy> AssetHierarchy { get; set; }

       // public DbSet<OfferList> OfferList { get; set; }
    }
}