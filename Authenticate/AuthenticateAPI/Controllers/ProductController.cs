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
   
    public class ProductController : ControllerBase
    {
        private readonly IdentityDBContext identitydbcontext;

        public ProductController(IdentityDBContext context)
        {
            this.identitydbcontext = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            var allProducts = await identitydbcontext.Products.ToListAsync();
            return allProducts;
        }
        [HttpGet("productsByCategory/{categoryId}")]
        public async Task<IEnumerable<ProductModel>> GetProductsByCategory(int categoryId)
        {
            var productsInCategory = await identitydbcontext.Products
                .Where(product => product.CategoryProduct.Id == categoryId)
                .ToListAsync();

            return productsInCategory;
        }
        [HttpPost("addProduct")]
        public async Task<IEnumerable<ProductModel>> AddProduct([FromBody] ProductModel newProduct)
        {
            if (newProduct == null)
            {
                Response.StatusCode = 400; // Bad Request
                return null;
            }

           
            identitydbcontext.Products.Add(newProduct);           
            await identitydbcontext.SaveChangesAsync();           
            var allProducts = await identitydbcontext.Products.ToListAsync();
            return allProducts;
        }
    
    }
