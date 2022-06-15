using FoodService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodService.Infrastructure.EntityConfigurations
{
    public class PackageSizeEntityTypeConfiguration : IEntityTypeConfiguration<PackageSize>
    {
        public void Configure(EntityTypeBuilder<PackageSize> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Grams);
        }
    }
}
