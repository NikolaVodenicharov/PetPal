using FoodService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodService.Infrastructure.EntityConfigurations
{
    public class FlavorEntityTypeConfiguration : IEntityTypeConfiguration<Flavor>
    {
        public void Configure(EntityTypeBuilder<Flavor> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name);
        }
    }
}
