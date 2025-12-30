using Microsoft.EntityFrameworkCore;

namespace AlfanoWebDev.Models
{
    public class AlfanoDbContext : DbContext
    {
        public AlfanoDbContext(DbContextOptions<AlfanoDbContext> options) : base(options) { }

        // This links your MediaAsset model to the database table
        public DbSet<MediaAsset> MediaAssets { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
    }
}