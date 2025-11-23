using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;
using Cartelmen.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Infrastructure.Repositories;
public class PersonRepository: IPersonRepository
{
    private readonly CartelmenDbContext _dbContext;

    public PersonRepository(CartelmenDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Person>> GetAllAsync()
        =>  await _dbContext.Person
            .Include(w => w.Contact)
            .IgnoreQueryFilters()
            .ToListAsync();
    
    public async Task<Person?> GetByIdAsync(Guid id) 
        => await _dbContext.Person
            .Include(w => w.Contact)
            .FirstOrDefaultAsync(w => w.Id == id);

    public async Task<Person> AddAsync(Person person)
    {
        _dbContext.Person.Add(person);
        await _dbContext.SaveChangesAsync();
        return person;
    }

    public async Task<Person?> UpdateAsync(Person person)
    {
        _dbContext.Person.Update(person);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0 ? person : default;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var result = await _dbContext.Person
            .Where(w => w.Id == id && !w.IsDeleted)
            .ExecuteUpdateAsync(w => w
                .SetProperty(p => p.IsDeleted, true)
                .SetProperty(p => p.DeletedAtUtc, DateTime.UtcNow)
            );

        return result > 0;
    }
}
