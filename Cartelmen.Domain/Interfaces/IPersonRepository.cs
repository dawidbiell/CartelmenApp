using Cartelmen.Domain.Entities;

namespace Cartelmen.Domain.Interfaces;
public interface IPersonRepository
{
    Task<Person> AddAsync(Person person, CancellationToken cancellationToken = default);
    Task<IEnumerable<Person>> GetAllAsync(CancellationToken cancellationToken  = default);
    Task<Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken  = default);
    Task<Person?> UpdateAsync(Person person, CancellationToken cancellationToken  = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken  = default);
}
