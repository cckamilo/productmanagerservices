using DataAccess.MongoDB.Interfaces.Configuration;

namespace DataAccess.MongoDB.Repository
{
    public class StoreDataBaseSettings : IStoreDataBaseSettings
    {
        public string collectionName { get; set; }
        public string connectionString { get; set; }
        public string dataBaseName { get; set; }
    }
}