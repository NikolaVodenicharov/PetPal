using AccessoriesService.Domain.Infrastructures;
using AccessoriesService.Domain.Models;
using AccessoriesService.Infrastructure.DataAccess;
using MongoDB.Driver;

namespace AccessoriesService.Infrastructure.Repositories
{
    public class CollarRepository : ICollarRepository
    {
        private readonly IMongoCollection<Collar> collars;

        public CollarRepository(IAccessoriesMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            collars = database.GetCollection<Collar>(settings.CollarsCollectionName);
        }

        public async Task<ICollection<Collar>> AllAsync()
        {
            return await collars.Find(c => true).ToListAsync();
        }

        public Collar Create (Collar collar)
        {
            collars.InsertOne(collar);

            return collar;
        }
    }
}
