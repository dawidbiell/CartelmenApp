using Cartelmen.Domain.Entities;

namespace Cartelmen.Application.Services;
public interface IWorkerService
{
    Task<Worker> Create (Worker worker);
    Task<IEnumerable<Worker>> GetAll();
    Task<Worker?> GetById(Guid id);
    Task<Worker?> Update(Worker worker);
    Task<bool> DeleteById(Guid id);
}
