using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AuthenticateAPI.Data;
using AuthenticateClassLibrary;
using AuthenticateAPI;
using Microsoft.EntityFrameworkCore;

namespace AuthenticateAPI.Controllers;

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    
    public class ShoppingCartController : ControllerBase
    {
        private readonly IdentityDBContext identitydbcontext;

        public ShoppingCartController(IdentityDBContext identitydbcontext)
        {
            this.identitydbcontext = identitydbcontext;
        }
        // {
        //     this.identitydbcontext = context;
        //     //_identitydbcontext = identitydbcontext;

        // }  
        [HttpGet(Name = "GetShoppingCart")]
      
    //public async Task<ShoppingCartModel> Get(string id)
    //public async Task<IEnumerable<ProductModel>> Get()
    public async Task<IEnumerable<ProductModel>> Get(string id)
    {
        
        var userName = User.Identity?.Name ?? string.Empty;       
        var userShoppingCart = await identitydbcontext.ShoppingCarts
            .Where(cart => cart.User == userName)
            .ToListAsync();
        // var userShoppingCart = await identitydbcontext.FindByNameAsync(User.Identity?.Name ?? string.Empty);
        //return $"{User.Identity?.Name ?? String.Empty} = {user?.Email ?? String.Empty}";

         return userShoppingCart;
    }
    [HttpPost("removeItem/{productId}")]
    public async Task<IEnumerable<ProductModel>> RemoveItem(int productId)
    {
        
        var userName = User.Identity?.Name ?? string.Empty;

      
        var userShoppingCart = await identitydbcontext.ShoppingCarts
            .Include(cart => cart.Products)
            .FirstOrDefaultAsync(cart => cart.User == userName);

        if (userShoppingCart == null)
        {
            Response.StatusCode = 404; 
            return null;
        }

         var productToRemove = userShoppingCart.Products.FirstOrDefault(p => p.Id == productId);

        if (productToRemove == null)
        {
            Response.StatusCode = 404; 
            return null;
        }

       
        userShoppingCart.Products.Remove(productToRemove);

        
        await identitydbcontext.SaveChangesAsync();

        return userShoppingCart.Products;
    }
         
    [HttpPost("addItem/{productId}")]
    public async Task<IEnumerable<ProductModel>> AddItem(int productId)
    {
       
        var userEmail = User.Identity?.Name ?? string.Empty;       
        var userShoppingCart = await identitydbcontext.ShoppingCarts
            .Include(cart => cart.Products)
            .FirstOrDefaultAsync(cart => cart.User == userEmail);

        if (userShoppingCart == null)
        {
           
            userShoppingCart = new ShoppingCartModel
            {
                User = userEmail,
                Products = new List<ProductModel>()
            };            

          
            identitydbcontext.ShoppingCarts.Add(userShoppingCart);
        }

       
        if (userShoppingCart.Products.Any(p => p.Id == productId))
        {
            Response.StatusCode = 400;
            return null;
        }

      
        var productToAdd = await identitydbcontext.Products.FindAsync(productId);

        if (productToAdd == null)
        {
            Response.StatusCode = 404;
            return null;
        }

       
        userShoppingCart.Products.Add(productToAdd);

        
        await identitydbcontext.SaveChangesAsync();

        return userShoppingCart.Products;
    }


}
