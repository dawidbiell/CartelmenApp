using AutoMapper;
using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Commands.WorkerCreate;

public class WorkerCreateCommandHandler : IRequestHandler<WorkerCreateCommand, Worker>
{
    private readonly IMapper _mapper;
    private readonly IWorkerRepository _workerRepository;

    public WorkerCreateCommandHandler(IMapper mapper, IWorkerRepository workerRepository)
    {
        _mapper = mapper;
        _workerRepository = workerRepository;
    }

    public async Task<Worker> Handle(WorkerCreateCommand request, CancellationToken cancellationToken)
    {
        var worker = _mapper.Map<Worker>(request);
        return await _workerRepository.AddAsync(worker);
    }
}