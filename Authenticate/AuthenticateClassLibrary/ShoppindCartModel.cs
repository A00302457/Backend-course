
namespace AuthenticateClassLibrary;

public class ShoppingCartModel : ProductModel
{
    public int SId { get; set; }
    public string? User { get; set; }
    public List<ProductModel> Products { get; set; }
}