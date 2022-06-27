using FoodService.Application.Queries.FoodSummary;

namespace FoodService.Application.Queries
{
    public record FoodDetailsQuery(int Id, string? Title, decimal SellPrice, string? Description)
        :FoodSummaryQuery(Id, Title, SellPrice);
}
