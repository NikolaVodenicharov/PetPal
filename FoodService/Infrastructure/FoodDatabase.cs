using FoodService.Domain.Models;
using FoodService.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FoodService.Infrastructure
{
    public class FoodDatabase : DbContext
    {
        public DbSet<Food> Foods {get; set;}
        public DbSet<Brand> Brands {get; set;}


        public FoodDatabase(DbContextOptions<FoodDatabase> options)
            : base(options)
        {

        }

        /// <summary>
        /// Using Fluent API Configuration, each configurations of entity is extracted to separate file into EntityConfiguration folder.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BrandEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FlavorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FoodCategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FoodEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PackageSizeEntityTypeConfiguration());
        }
    }
}
