using Shared.Models;
using System.Net.Http.Json;

namespace Client.Services.FoodService
{
    public class FoodService : IFoodService
    {
        private const string ApiFood = "api/Food/all";

        private readonly HttpClient client;

        public FoodService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<FoodSummaryDto>> All()
        {
            try
            {
                var foods = await client.GetFromJsonAsync<IEnumerable<FoodSummaryDto>>(ApiFood);

                return foods;
            }
            catch (Exception e)
            {
                var massage = e.Message;
                throw;
            }
        }
    }
}
