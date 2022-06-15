using System.Collections.ObjectModel;

namespace FoodService.Domain.Models
{
    /// <summary>
    /// That is the stock that we are selling. 
    /// It is our main class the others are support.
    /// Could be our IRootAgregate
    /// </summary>
    public class Food : Product
    {
        private Food() { }

        public Food(AnimalType animal, Brand brand, PackageSize packageSize, Flavor flavour, FoodCategory foodCategory,
                    string title, decimal purchasePrice, decimal sellPrice, int quantity, string description, decimal discountPercentage = 0) : 
            base(title, purchasePrice, sellPrice, quantity, description, discountPercentage)
        {
            this.Animal = animal;
            this.Brand = brand;
            this.PackageSize = packageSize;
            this.Flavor = flavour;
            this.FoodCategory = foodCategory;
        }

        public int Id { get; private set; }
        public AnimalType? Animal { get; private set; }
        public Brand? Brand { get; private set; }
        public PackageSize? PackageSize { get; private set; }
        public Flavor? Flavor { get; private set; }
        public FoodCategory? FoodCategory { get; private set; }
    }
}
