using Cartelmen.Domain.Entities;
using Cartelmen.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Server.DemoServices;

public class WorkerService : IWorkerService
{
    private readonly CartelmenDbContext _db;

    public WorkerService(CartelmenDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Person?>> GetAllAsync()
    {
        return await _db.Person.IgnoreQueryFilters().ToListAsync();
    }

    public async Task<Person?> GetByIdAsync(int id)
    {
        return await _db.Person.FindAsync(id);
    }

    public async Task<Person?> AddAsync(Person? worker)
    {
        _db.Person.Add(worker);
        await _db.SaveChangesAsync();
        return worker;
    }

    public async Task<Person?> UpdateAsync(Person? worker)
    {
        _db.Person.Update(worker);
        await _db.SaveChangesAsync();
        return worker;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var result = await _db.Person
            .Where(w => w.Id == id && !w.IsDeleted)
            .ExecuteUpdateAsync(w => w
                .SetProperty(p => p.IsDeleted, true)
                .SetProperty(p => p.DeletedAtUtc, DateTime.UtcNow)
            );

        return result > 0;
    }
}