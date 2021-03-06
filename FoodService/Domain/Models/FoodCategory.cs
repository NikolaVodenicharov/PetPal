namespace FoodService.Domain.Models
{
    /// <summary>
    /// Different types of food like dry, wet (canned), for puppies
    /// </summary>
    public class FoodCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}