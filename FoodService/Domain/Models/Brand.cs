namespace FoodService.Domain.Models
{
    /// <summary>
    /// Name of the company that is creating the product
    /// </summary>
    public class Brand
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}