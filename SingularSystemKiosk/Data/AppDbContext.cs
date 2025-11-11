using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SingularSystemKiosk.Models;

namespace SingularSystemKiosk.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

      
        public DbSet<AppUser> Users { get; set; }
     

        
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

       
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderedItems> OrderedItems { get; set; }
        public DbSet<PaymentTransaction> Transaction { get; set; }

    }
}
