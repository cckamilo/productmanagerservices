namespace DataAccess.MongoDB.Interfaces.Configuration
{
    public interface IStoreDataBaseSettings
    {
        string collectionName { get; set; }
        string connectionString { get; set; }
        string dataBaseName { get; set; }
    }
}