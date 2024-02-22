namespace AuthenticateClassLibrary;
using AuthenticateClassLibrary;

public class ProductModel
{
        public int Id { get; set; }
        public int Price { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public CategoryModel CategoryProduct { get; set; }
}