using Cartelmen.Domain.Entities;

namespace Cartelmen.Server.DemoServices
{
    public interface IWorkerService
    {
        Task<IEnumerable<Person?>> GetAllAsync();
        Task<Person?> GetByIdAsync(int id);
        Task<Person?> AddAsync(Person? worker);
        Task<Person?> UpdateAsync(Person? worker);
        Task<bool> DeleteByIdAsync(int id);
    }
}