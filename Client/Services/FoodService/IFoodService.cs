using Shared.Models;

namespace Client.Services.FoodService
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodSummaryDto>> All();
    }
}
