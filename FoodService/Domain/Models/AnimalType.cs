namespace FoodService.Domain.Models
{
    /// <summary>
    /// This could be like Dog, Cat, Fish, Burd, Small pet (hamsters), Reptile, Farm (horse)
    /// </summary>
    public class AnimalType
    {       
        public int Id { get; set; }
       
        public string? Name { get; set; }

    }
}