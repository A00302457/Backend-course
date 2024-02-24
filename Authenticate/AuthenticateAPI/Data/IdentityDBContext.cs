using Microsoft.EntityFrameworkCore;
using AuthenticateClassLibrary;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AuthenticateAPI.Data;



namespace AuthenticateAPI.Data
{
    public class IdentityDBContext : DbContext
    {
       
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ShoppingCartModel> ShoppingCarts { get; set; }
        //public Dbset<TestModel> TestModels { get; set; }
        public IdentityDBContext() { }      
        public IdentityDBContext(DbContextOptions<IdentityDbContext> options) : base(options) {}

        

      
       
    }

}
