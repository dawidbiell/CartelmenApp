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

    public async Task<IEnumerable<Worker?>> GetAllAsync()
    {
        return await _db.Workers.IgnoreQueryFilters().ToListAsync();
    }

    public async Task<Worker?> GetByIdAsync(Guid id)
    {
        return await _db.Workers.FindAsync(id);
    }

    public async Task<Worker?> AddAsync(Worker? worker)
    {
        _db.Workers.Add(worker);
        await _db.SaveChangesAsync();
        return worker;
    }

    public async Task<Worker?> UpdateAsync(Worker? worker)
    {
        _db.Workers.Update(worker);
        await _db.SaveChangesAsync();
        return worker;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var result = await _db.Workers
            .Where(w => w.Id == id && !w.IsDeleted)
            .ExecuteUpdateAsync(w => w
                .SetProperty(p => p.IsDeleted, true)
                .SetProperty(p => p.DeletedAtUtc, DateTime.UtcNow)
            );

        return result > 0;
    }
}