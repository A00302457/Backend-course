using AuthenticateClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AuthenticateTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
    }


    /////////////////................... Test Method for CategoryModel.......................////////////////////
     [TestMethod]
    public void CategoryModel_Id_IsItSetCorrectly()
    {       
        var category = new CategoryModel();     
        category.Id = 1;       
        Assert.AreEqual(1, category.Id);
    }
    [TestMethod]
    public void CategoryModel_Description_IsItSetCorrectly()
    {        
        var category = new CategoryModel();       
        category.Description = "TestCategory";       
        Assert.AreEqual("TestCategory", category.Description);
    }
    [TestMethod]
    public void CategoryModel_DefaultId_IsItZero()
    {      
        var category = new CategoryModel();       
        Assert.AreEqual(0, category.Id);
    }
    [TestMethod]
    public void CategoryModel_DefaultDescription_IsItNull()
    {      
        var category = new CategoryModel();       
        Assert.IsNull(category.Description);
    }


/////////////////................... Test Method for ProductModel.......................////////////////////
    [TestMethod]
    public void ProductModel_Id_IsItSetCorrectly()
    {       
        var product = new ProductModel();       
        product.Id = 1;
        Assert.AreEqual(1, product.Id);
    }

    [TestMethod]
    public void ProductModel_Price_IsItSetCorrectly()
    {       
        var product = new ProductModel();    
        product.Price = 50;      
        Assert.AreEqual(50, product.Price);
    }

    [TestMethod]
    public void ProductModel_Name_IsItSetCorrectly()
    {    
        var product = new ProductModel();       
        product.Name = "TestProduct";       
        Assert.AreEqual("TestProduct", product.Name);
    }

    [TestMethod]
    public void ProductModel_CategoryProduct_IsItNotNullByDefault()
    {       
        var product = new ProductModel();
        Assert.IsNull(product.CategoryProduct);
    }

    [TestMethod]
    public void ProductModel_DefaultValues_AreSet()
    {        
        var product = new ProductModel();        
        Assert.AreEqual(0, product.Id);
        Assert.AreEqual(0, product.Price);
        Assert.IsNull(product.Name);
        Assert.IsNull(product.Description);
        Assert.IsNull(product.CategoryProduct);
    }


    /////////////////................... Test Method for ShoppingCartModel.......................////////////////////
    [TestMethod]
    public void ShoppingCartModel_Id_IsItSetCorrectly()
    {       
        var shoppingCart = new ShoppingCartModel();       
        shoppingCart.Id = 1;       
        Assert.AreEqual(1, shoppingCart.Id);
    }

    [TestMethod]
    public void ShoppingCartModel_User_IsItSetCorrectly()
    {       
        var shoppingCart = new ShoppingCartModel();       
        shoppingCart.User = "TestUser"; 
        Assert.AreEqual("TestUser", shoppingCart.User);
    }

    [TestMethod]
    public void ShoppingCartModel_Products_IsItNotNullByDefault()
    {       
        var shoppingCart = new ShoppingCartModel();       
        Assert.IsNull(shoppingCart.Products);
    }

    [TestMethod]
    public void ShoppingCartModel_DefaultId_IsItZero()
    {       
        var shoppingCart = new ShoppingCartModel();       
        Assert.AreEqual(0, shoppingCart.Id);
    }

}