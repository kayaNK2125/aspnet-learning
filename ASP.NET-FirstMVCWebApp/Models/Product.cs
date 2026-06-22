namespace FirstMvcWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; } = 0.00m; // Default value for Price
        public string Color { get; set; } = null!;
    }
}
