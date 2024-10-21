namespace MyEcommerceApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public Category Category { get; set; } = new Category();

        public Product()
        {
        }
    }
}
