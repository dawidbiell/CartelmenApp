using Cartelmen.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cartelmen.Application.DTOs;

namespace Cartelmen.Application.Services
{
    public interface ITestService
    {
        Task<SpotPersonsDto?> PersonsGetAll(int id, CancellationToken ct);
        Task<Spot> Create(SpotDto building, CancellationToken cancellationToken);
        Task<Spot?> GetById(int id, CancellationToken cancellationToken);
        Task<IEnumerable<SpotDto>> GetAll(CancellationToken cancellationToken);
        Task<Spot?> Update(Spot building, CancellationToken cancellationToken);
        Task<bool> DeleteById(int id, CancellationToken cancellationToken);
    }
}