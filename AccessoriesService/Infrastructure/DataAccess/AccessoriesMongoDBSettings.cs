namespace AccessoriesService.Infrastructure.DataAccess
{
    public class AccessoriesMongoDBSettings : IAccessoriesMongoDBSettings
    {
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
        public string CollarsCollectionName { get; set; } = String.Empty;

    }
}
