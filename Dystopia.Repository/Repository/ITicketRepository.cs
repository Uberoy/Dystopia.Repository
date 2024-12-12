using Dystopia.Repository.Entities;

namespace Dystopia.Repository.Repository;

public interface ITicketRepository
{
    Task<Ticket> GetByIdAsync(string id);
    Task<IEnumerable<Ticket>> GetManyAsync(int start, int count);
    Task AddOneAsync(Ticket item);
    Task PutOneAsync(string id, Ticket item);
    Task DeleteOneAsync(string id);
}