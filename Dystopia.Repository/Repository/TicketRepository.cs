using Dystopia.Repository.DbContext;
using Dystopia.Repository.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Dystopia.Repository.Repository;

public class TicketRepository : ITicketRepository
{
    private readonly IMongoCollection<Ticket> _collection;

    public TicketRepository(IMongoDbContext context)
    {
        _collection = context.GetCollection<Ticket>("Tickets");
    }

    public async Task<Ticket> GetByIdAsync(string id)
    {
        if (!ObjectId.TryParse(id, out var objectId))
        {
            throw new ArgumentException("Invalid ID format", nameof(id));
        }

        var filter = Builders<Ticket>.Filter.Eq(t => t.Id, objectId.ToString());
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Ticket>> GetManyAsync(int start, int count)
    {
        var filter = Builders<Ticket>.Filter.Empty;
        var tickets = await _collection.Find(filter).Skip(start).Limit(count).ToListAsync();
        return tickets;
    }

    public async Task AddOneAsync(Ticket item)
    {
        await _collection.InsertOneAsync(item);
    }

    public async Task PutOneAsync(string id, Ticket item)
    {
        var filter = Builders<Ticket>.Filter.Eq(t => t.Id, id);

        var update = Builders<Ticket>.Update
            .Set(t => t.Content, item.Content)
            .Set(t => t.DateCreated, item.DateCreated)
            .Set(t => t.UserId, item.UserId);

        _collection.UpdateOne(filter, update);
    }

    public async Task DeleteOneAsync(string id)
    {
        var filter = Builders<Ticket>.Filter.Eq(t => t.Id, id);

        _collection.DeleteOne(filter);
    }
}