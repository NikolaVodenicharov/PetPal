using Shared.Models;
using System.Net.Http.Json;

namespace Client.Services.FoodService
{
    public class FoodService : IFoodService
    {
        public const string ApiFood = "Food";

        public static string Some = "Some";

        private readonly HttpClient client;

        public FoodService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IList<FoodSummaryDto>> All()
        {
            try
            {
                var response = await client.GetAsync(ApiFood + "/all");

                if (!response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new List<FoodSummaryDto>();
                }

                var foods = await response.Content.ReadFromJsonAsync<List<FoodSummaryDto>>();

                //var foods = await client.GetFromJsonAsync<List<FoodSummaryDto>>(ApiFood + "/all");

                return foods;
            }
            catch (Exception e)
            {
                var massage = e.Message;
                throw;
            }
        }

        public async Task<FoodDetailsDto> Get(int id)
        {
            try
            {
                var response = await client.GetAsync(ApiFood + $"/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default(FoodDetailsDto);
                }

                return await response.Content.ReadFromJsonAsync<FoodDetailsDto>();

               //var food = await client.GetFromJsonAsync<FoodDetailsDto>(ApiFood + $"/{id}");
            }
            catch (Exception e)
            {
                // Log exception
                throw;
            }
        }
    }
}
