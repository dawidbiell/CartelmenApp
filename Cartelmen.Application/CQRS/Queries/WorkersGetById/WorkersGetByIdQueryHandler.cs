using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Queries.WorkersGetById;

public class WorkersGetByIdQueryHandler : IRequestHandler<WorkersGetByIdQuery, WorkerDto>
{
    private readonly IMapper _mapper;
    private readonly IWorkerRepository  _workerRepository;

    public WorkersGetByIdQueryHandler(IMapper mapper, IWorkerRepository workerRepository)
    {
         _mapper = mapper;
        _workerRepository = workerRepository;
    }

    public async Task<WorkerDto> Handle(WorkersGetByIdQuery request, CancellationToken cancellationToken)
    {
        var workerDto = _mapper.Map<WorkerDto>(
            await _workerRepository.GetByIdAsync(request.Id));
        return  workerDto;
    }
}