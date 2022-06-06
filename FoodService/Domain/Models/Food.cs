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
        public Food(Collection<AnimalType> animals, Brand brand, PackageSize packageSize, Flavor flavour, FoodCategory foodCategory,
                    string title, decimal purchasePrice, decimal sellPrice, int quantity, string description, decimal discountPercentage = 0) : 
            base(title, purchasePrice, sellPrice, quantity, description, discountPercentage)
        {
            this.Animals = new List<AnimalType>(animals.Count);
            this.Animals.AddRange(animals);

            this.Brand = brand;
            this.PackageSize = packageSize;
            this.Flavour = flavour;
            this.FoodCategory = foodCategory;
        }

        public int Id { get; private set; }
        public List<AnimalType> Animals { get; private set; }
        public Brand? Brand { get; private set; }
        public PackageSize? PackageSize { get; private set; }
        public Flavor Flavour { get; }
        public Flavor? Flavor { get; private set; }
        public FoodCategory? FoodCategory { get; private set; }
        public Collection<AnimalType> Animals1 { get; }
    }
}
