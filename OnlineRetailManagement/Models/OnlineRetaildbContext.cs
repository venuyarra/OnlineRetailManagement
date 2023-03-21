using Microsoft.EntityFrameworkCore;

namespace OnlineRetailManagement.Models
{
    public class OnlineRetaildbContext:DbContext
    {
        public OnlineRetaildbContext(DbContextOptions<OnlineRetaildbContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Product> products { get;set; }
        public DbSet<ProductsInCart> productsincart { get; set; }


    }
}
