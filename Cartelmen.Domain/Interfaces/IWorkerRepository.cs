using Cartelmen.Domain.Entities;

namespace Cartelmen.Domain.Interfaces;
public interface IWorkerRepository
{
    Task<Worker> AddAsync(Worker worker);
    Task<IEnumerable<Worker>> GetAllAsync();
    Task<Worker?> GetByIdAsync(Guid id);
    Task<Worker?> UpdateAsync(Worker worker);
    Task<bool> DeleteByIdAsync(Guid id);
}
