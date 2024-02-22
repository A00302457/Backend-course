using Microsoft.EntityFrameworkCore;
using AuthenticateClassLibrary;

namespace AuthenticateAPI.Data
{
    public class IdentityDbContext : DbContext
    {
        // create a db context for the database using ToDoListClassLibrary
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ShoppingCartModel> ShoppingCarts { get; set; }

        public IdentityDbContext() { }

        // referecen for database migration
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) => Database.Migrate();

        //database configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite();
    }

}
