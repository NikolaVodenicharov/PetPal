using FoodService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodService.Infrastructure.EntityConfigurations
{
    public class FoodEntityTypeConfiguration : IEntityTypeConfiguration<Food>
    {     
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Title);
            builder.Property(f => f.AvaragePurchasePricePerUnit);
            builder.Property(f => f.SellPrice);
            builder.Property(f => f.DiscountPercentage);
            builder.Property(f => f.Quantity);
            builder.Property(f => f.Description);
        }
    }
}
