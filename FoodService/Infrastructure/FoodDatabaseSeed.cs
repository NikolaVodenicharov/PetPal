using FoodService.Domain.Models;

namespace FoodService.Infrastructure
{
    public class FoodDatabaseSeed
    {
        private readonly FoodDatabase foodDatabase;

        public FoodDatabaseSeed(FoodDatabase foodDatabase)
        {
            this.foodDatabase = foodDatabase;
        }

        public void GenerateFoods()
        {
            AddBrands();
            AddFlavors();
            AddPackageSizes();
            AddFoodCategories();
            AddAnimalDog();

            List<Brand> brands = foodDatabase.Brands.ToList();
            List<Flavor> flavors = foodDatabase.Flavors.ToList();
            List<PackageSize> packageSizes = foodDatabase.PackageSizes.ToList();
            List<FoodCategory> foodCategories = foodDatabase.FoodCategories.ToList();
            AnimalType dog = foodDatabase.Animals.First();

            var random = new Random();

            var insertFoodsNumber = 50;

            for (int i = 0; i < insertFoodsNumber; i++)
            {
                Food food = new(
                    dog,
                    brands[random.Next(0, brands.Count)],
                    packageSizes[random.Next(0, packageSizes.Count)],
                    flavors[random.Next(0, flavors.Count)],
                    foodCategories[random.Next(0, foodCategories.Count)],
                    $"Title - product {i}",
                    10.95m,
                    12.95m,
                    i + 5,
                    "No description");

                foodDatabase.Foods.Add(food);
            }

            foodDatabase.SaveChanges();
        }
     
        private void AddBrands()
        {
            List<string> brands = new() { "Pedigree", "Hills", "Pero", "Symply", "Acana", "Eukanuba", "Canagan" };

            foreach (var brand in brands)
            {
                foodDatabase.Brands.Add(new Brand { Name = brand });
            }

            foodDatabase.SaveChanges();
        }
        private void AddFlavors()
        {
            List<string> flavors = new() { "Chiken", "Beef", "Turkeey", "Pork", "Lamb" };

            foreach (var flavor in flavors)
            {
                foodDatabase.Flavors.Add(new Flavor { Name = flavor });
            }

            foodDatabase.SaveChanges();
        }
        private void AddPackageSizes()
        {
            List<decimal> sizes = new() { 500, 1000, 2000 };

            foreach (var size in sizes)
            {
                foodDatabase.PackageSizes.Add(new PackageSize { Grams = size });
            }

            foodDatabase.SaveChanges();
        }
        private void AddFoodCategories()
        {
            List<string> foodCategories = new() { "Dry", "Wet" };

            foreach (var foodCategory in foodCategories)
            {
                foodDatabase.FoodCategories.Add(new FoodCategory { Name = foodCategory });
            }

            foodDatabase.SaveChanges();
        }
        private void AddAnimalDog()
        {
            AnimalType animal = new() { Name = "Dog" };

            foodDatabase.Animals.Add(animal);

            foodDatabase.SaveChanges();
        }
    }
}
