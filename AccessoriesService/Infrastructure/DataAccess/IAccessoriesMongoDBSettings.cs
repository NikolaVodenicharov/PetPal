namespace AccessoriesService.Infrastructure.DataAccess
{
    public interface IAccessoriesMongoDBSettings
    {      
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CollarsCollectionName { get; set; }
    }
}