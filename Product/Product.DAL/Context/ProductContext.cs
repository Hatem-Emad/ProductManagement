using Microsoft.EntityFrameworkCore;
using Product.DAL.Entities;

namespace Product.DAL.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Item>()
            //    .HasOne(i => i.Category)
            //    .WithMany()
            //    .HasForeignKey(x => x.CategoryId)
            //    .HasPrincipalKey(c => c.ID);
        }
    }
}
