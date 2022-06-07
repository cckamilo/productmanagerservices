using System;
using DataAccess.MongoDB.Models;

namespace DataAccess.MongoDB.Interfaces.Repository
{
    public interface ISettingsRepository : IMongoDbRepository<Settings>
    {

    }
}
