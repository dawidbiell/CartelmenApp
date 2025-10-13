using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Commands.CreateWorker;

public class WorkerCommandHandler : IRequestHandler<CreateWorkerCommand, Worker>
{
    private readonly IMapper _mapper;
    private readonly IWorkerRepository _workerRepository;

    public WorkerCommandHandler(IMapper mapper, IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
        _mapper = mapper;
    }

    public async Task<Worker> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
    {
        var worker = _mapper.Map<Worker>(request);
        return await _workerRepository.AddAsync(worker);
    }
}