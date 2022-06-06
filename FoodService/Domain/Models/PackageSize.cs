namespace FoodService.Domain.Models
{
    /// <summary>
    /// This is the weight of the product in grams. If we need pounds we will convert it in the frond end.
    /// </summary>
    public class PackageSize
    {
        public int Id { get; set; }
        public decimal Grams { get; set; }
    }
}