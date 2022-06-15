using FoodService.Domain.Models;
using FoodService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodService.Infrastructure.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private FoodDatabase database;

        public FoodRepository(FoodDatabase database)
        {
            this.database = database;
        }

        public void Add(Food entity)
        {
            database
                .Add(entity);

            database
                .SaveChanges();
        }

        // if entiyty with that id doesnt exist ?
        public void Delete(int id)
        {
            database
                .Foods
                .Remove(GetById(id));

            database
                .SaveChanges();
        }

        public IEnumerable<Food> GetAll()
        {
            var entitites = database.Foods.ToList();

            return entitites;
        }

        public Food GetById(int id)
        {
            var entity = database
                .Foods
                .Where(x => x.Id == id)
                .FirstOrDefault();


            return entity;
        }

        public void Update(Food entity)
        {
            database
                .Foods
                .Update(entity);

            database
                .SaveChanges();
        }
    }
}
