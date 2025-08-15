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
    }
}
