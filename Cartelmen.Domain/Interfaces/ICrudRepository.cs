namespace Cartelmen.Domain.Interfaces;

public interface ICrudRepository<T>
{
    Task<T?> AddAsync(T? entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken  = default);
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken  = default);
    Task<T?> UpdateAsync(T? entity, CancellationToken cancellationToken  = default);
    Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken  = default);
}