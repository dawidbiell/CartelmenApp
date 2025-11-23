using Cartelmen.Domain.Entities;

namespace Cartelmen.Domain.Interfaces;
public interface IPersonRepository
{
    Task<Person> AddAsync(Person person);
    Task<IEnumerable<Person>> GetAllAsync();
    Task<Person?> GetByIdAsync(Guid id);
    Task<Person?> UpdateAsync(Person person);
    Task<bool> DeleteByIdAsync(Guid id);
}
