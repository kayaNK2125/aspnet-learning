namespace FirstMvcWebApp.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; } = 0.00m; 
        public string Color { get; set; } = null!;
    }
}

// In Easy Language: Productdto = Data Transfer Object for Product data(UI/API)