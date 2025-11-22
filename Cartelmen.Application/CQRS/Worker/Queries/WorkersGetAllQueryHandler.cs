using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Worker.Queries;

public class WorkerGetAllQueryHandler : IRequestHandler<WorkerGetAllQuery, IEnumerable<WorkerDto>>
{
    private readonly IMapper  _mapper;
    private readonly IWorkerRepository  _workerRepository;

    public WorkerGetAllQueryHandler( IMapper mapper, IWorkerRepository workerRepository)
    {
        _mapper = mapper;
        _workerRepository = workerRepository;
    }

    public async Task<IEnumerable<WorkerDto>> Handle(WorkerGetAllQuery request, CancellationToken cancellationToken)
    {
        var list = await _workerRepository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<WorkerDto>>(list);
        return dtos;
    }
}