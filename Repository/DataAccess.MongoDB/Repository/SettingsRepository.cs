using System;
using DataAccess.MongoDB.Interfaces.Configuration;
using DataAccess.MongoDB.Interfaces.Repository;
using DataAccess.MongoDB.Models;

namespace DataAccess.MongoDB.Repository
{
    public class SettingsRepository : MongoDbRepository<Settings>, ISettingsRepository
    {
        public SettingsRepository(IStoreDataBaseSettings settings) : base(settings)
        {
        }
    }
}
