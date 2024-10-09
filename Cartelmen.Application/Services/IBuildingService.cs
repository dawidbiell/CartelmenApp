using Cartelmen.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cartelmen.Application.Services
{
    public interface IBuildingService
    {
        Task<Building> Create(Building building);
        Task<Building?> GetById(int id);
        Task<IEnumerable<Building>> GetAll();
        Task<Building?> Update(Building building);
        Task<bool> DeleteById(int id);
    }
}