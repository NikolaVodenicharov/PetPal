using FoodService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace FoodService.Application.Queries.FoodSummary
{
    public class FoodSummaryAllHandler
    {
        private readonly FoodDatabase foodDatabase;

        public FoodSummaryAllHandler(FoodDatabase foodDatabase)
        {
            this.foodDatabase = foodDatabase;
        }

        public async Task<ICollection<FoodSummaryQuery>> Handle()
        {
            return await this.foodDatabase
                .Foods
                .Select(f => new FoodSummaryQuery(f.Id, f.Title, f.SellPrice))
                .ToListAsync();
        }
    }
}
