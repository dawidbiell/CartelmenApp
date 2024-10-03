using Cartelmen.Domain.Entities;

namespace Cartelmen.Server.DemoServices
{
    public interface IWorkerService
    {
        Task<IEnumerable<Worker?>> GetAllAsync();
        Task<Worker?> GetByIdAsync(Guid id);
        Task<Worker?> AddAsync(Worker? worker);
        Task<Worker?> UpdateAsync(Worker? worker);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}