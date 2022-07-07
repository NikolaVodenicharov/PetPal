namespace Shared.Models
{
    public class FoodSummaryDto
    {
        public FoodSummaryDto(int id, string? title, decimal sellPrice)
        {
            this.Id = id;
            this.Title = title;
            this.SellPrice = sellPrice;
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal SellPrice { get; set; }
    }
}
