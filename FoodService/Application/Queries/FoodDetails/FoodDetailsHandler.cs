using FoodService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FoodService.Application.Queries.FoodDetails
{
    public class FoodDetailsHandler
    {
        private readonly FoodDatabase foodDatabase;

        public FoodDetailsHandler(FoodDatabase foodDatabase)
        {
            this.foodDatabase = foodDatabase;
        }

        public async Task<FoodDetailsQuery> Handle(int id)
        {
            return await this.foodDatabase
                .Foods
                .Where(f => f.Id == id)
                .Select(f => new FoodDetailsQuery(f.Id, f.Title, f.SellPrice, f.Description))
                .FirstOrDefaultAsync();
        }
    }
}
