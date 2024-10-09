using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;

namespace Cartelmen.Application.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }
        public async Task<Worker> Create (Worker worker)
        {
            return await _workerRepository.AddAsync(worker);
        }

        public async Task<IEnumerable<Worker>> GetAll()
        {
            return await _workerRepository.GetAllAsync();
        }

        public async Task<Worker?> GetById(Guid id)
        {
            return await _workerRepository.GetByIdAsync(id);
        }

        public async Task<Worker?> Update(Worker worker)
        {
            return await _workerRepository.UpdateAsync(worker);
        }

        public async Task<bool> DeleteById(Guid id)
        {
            return await _workerRepository.DeleteByIdAsync(id);
        }
    }
}