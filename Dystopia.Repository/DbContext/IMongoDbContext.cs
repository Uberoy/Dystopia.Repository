using MongoDB.Driver;

namespace Dystopia.Repository.DbContext;

public interface IMongoDbContext
{
    IMongoCollection<T> GetCollection<T>(string name);
}