using Microsoft.EntityFrameworkCore;
namespace wishlist.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        { }
 
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items {get; set;}
        public DbSet<Wish> Wishes {get; set;}
    }
}
