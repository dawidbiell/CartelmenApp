using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;
using Cartelmen.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Infrastructure.Repositories;
public class WorkerRepository: IWorkerRepository
{
    private readonly CartelmenDbContext _dbContext;

    public WorkerRepository(CartelmenDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Worker>> GetAllAsync()
    {
        return await _dbContext.Workers
            .IgnoreQueryFilters()
            .ToListAsync();
    }

    public async Task<Worker?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Workers.FindAsync(id);
    }

    public async Task<Worker> AddAsync(Worker worker)
    {
        _dbContext.Workers.Add(worker);
        await _dbContext.SaveChangesAsync();
        return worker;
    }

    public async Task<Worker?> UpdateAsync(Worker worker)
    {
        _dbContext.Workers.Update(worker);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0 ? worker : default;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var result = await _dbContext.Workers
            .Where(w => w.Id == id && !w.IsDeleted)
            .ExecuteUpdateAsync(w => w
                .SetProperty(p => p.IsDeleted, true)
                .SetProperty(p => p.DeletedAtUtc, DateTime.UtcNow)
            );

        return result > 0;
        //var worker = await _dbContext.Workers.FindAsync(id);
        //if (worker == null)
        //{
        //    return false;
        //}

        //_dbContext.Workers.Remove(worker);
        //await _dbContext.SaveChangesAsync();
        //return true;
    }
}
