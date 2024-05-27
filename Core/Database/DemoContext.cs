using Core.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Database
{
    public class DemoContext : DbContext
    {
        public string DbPath { get; } = string.Empty;

        public DemoContext(DbContextOptions<DemoContext> options) : base(options) { }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductTagEntity> ProductTags { get; set; }
    }
}
