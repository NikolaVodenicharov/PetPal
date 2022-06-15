using FoodService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodService.Infrastructure.EntityConfigurations
{
    public class AnimalTypeEntityTypeConfiguration : IEntityTypeConfiguration<AnimalType>
    {
        public void Configure(EntityTypeBuilder<AnimalType> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name);
        }
    }
}
