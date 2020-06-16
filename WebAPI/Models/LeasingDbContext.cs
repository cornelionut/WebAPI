using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Models
{
    public class LeasingDbContext : DbContext
    {
        //DbContextOptions ce db este folosita si detalii de conectare ca sunt primite ca parametrii din Startup.cs prin DependencyInjection
        public LeasingDbContext(DbContextOptions<LeasingDbContext> options) : base(options)
        {

        }

        public DbSet<AssetHierarchy> AssetHierarchy { get; set; }

        public DbSet<LeasingDocument> LeasingDocument { get; set; }

        public DbSet<Document> Document { get; set; }

        public DbSet<Register> Users { get; set; }
    }
}