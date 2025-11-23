using Cartelmen.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cartelmen.Application.DTOs;

namespace Cartelmen.Application.Services
{
    public interface IBuildingService
    {
        Task<Spot> Create(SpotDto building);
        Task<Spot?> GetById(int id);
        Task<IEnumerable<SpotDto>> GetAll();
        Task<Spot?> Update(Spot building);
        Task<bool> DeleteById(int id);
    }
}