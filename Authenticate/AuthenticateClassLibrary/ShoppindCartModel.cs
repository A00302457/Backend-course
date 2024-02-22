namespace AuthenticateClassLibrary;
using AuthenticateClassLibrary;

public class ShoppingCartModel : ProductModel
{
    public int Id { get; set; }
    public string? User { get; set; }
    public List<ProductModel> Products { get; set; }
}