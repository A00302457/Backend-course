using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AuthenticateAPI.Data;
using AuthenticateClassLibrary;

namespace AuthenticateAPI.Controllers;

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    
    public class ShoppingCartController : ControllerBase
    {
        private readonly IdentityDBContext identitydbcontext;

        public ShoppingCartController(IdentityDBContext context)
        {
            this.identitydbcontext = context;
           // _identityDbContext = identityDbContext;

        }  
        [HttpGet]
        public IEnumerable<ShoppingCartModel> Get()
        {
            return identitydbcontext.ShoppingCarts.ToArray();
        }  
       // [HttpPost("AddToCart/{Id}")]
        // public async Task<IEnumerable<ShoppingCartModel>> AddToCart(int Id)
        // {
        //    // Retrieve the product asynchronously
        //     var product = await _identityDbContext.Products.FindAsync(Id);

        //     if (product == null)
        //     {
        //         return BadRequest("Product not found");
        //     }

        //     // Retrieve the current user's email from the claims
        //     var userEmail = User.FindFirst()?.Value;

        //     // Retrieve the user's shopping cart asynchronously
        //     var cart = await _identityDbContext.ShoppingCarts
        //         .Include(sc => sc.Products) // Ensure Products navigation property is loaded
        //         .FirstOrDefaultAsync(x => x.User == userEmail);

        //     if (cart == null)
        //     {
        //         // Create a new shopping cart if it doesn't exist
        //         cart = new ShoppingCartModel
        //         {
        //             User = userEmail,
        //             Products = new List<ProductModel>()
        //         };
        //         _identityDbContext.ShoppingCarts.Add(cart);
        //     }

        //     // Add the product to the shopping cart
        //     cart.Products.Add(product);

        //     await _identityDbContext.SaveChangesAsync();

        //     // Return the updated shopping carts
        //     return await _identityDbContext.ShoppingCarts.Include(sc => sc.Products).ToArrayAsync();
       // }

        //}
    }
