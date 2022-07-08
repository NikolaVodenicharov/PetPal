using Shared.Models;

namespace Client.Services.FoodService
{
    public interface IFoodService
    {
        Task<IList<FoodSummaryDto>> All();

        Task<FoodDetailsDto> Get(int id);
    }
}
