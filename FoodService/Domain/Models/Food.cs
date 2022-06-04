namespace FoodService.Domain.Models
{
    public class Food
    {
        public Animal? Animal { get; set; }
        public Brand? Brand { get; set; }
        public PackageSize? PackageSize { get; set; }
        public Flavor? Flavor { get; set; }
        public FoodCategory? FoodCategory { get; set; }

    }
}
