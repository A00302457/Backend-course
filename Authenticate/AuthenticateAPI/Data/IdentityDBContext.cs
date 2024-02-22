using Microsoft.EntityFrameworkCore;
using AuthenticateClassLibrary;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AuthenticateAPI.Data;
using AuthenticateClassLibrary;

namespace AuthenticateAPI.Data
{
    public class IdentityDBContext : DbContext
    {
        // create a db context for the database using ToDoListClassLibrary
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ShoppingCartModel> ShoppingCarts { get; set; }

        public IdentityDBContext() { }

        // referecen for database migration
        public IdentityDBContext(DbContextOptions<IdentityDbContext> options) : base(options) {}

        //database configuration
       
    }

}
