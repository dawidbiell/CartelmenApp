using AutoMapper;
using Cartelmen.Application.CQRS.Spot.Queries;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Building.Queries;

public class SpotGetByIdQueryHandler :  IRequestHandler<SpotGetByIdQuery,SpotDto>
{
    private readonly ISpotRepository _spotRepository;
    private readonly IMapper _mapper;

    public SpotGetByIdQueryHandler(ISpotRepository repository, IMapper mapper)
    {
        _spotRepository = repository;
        _mapper = mapper;
    }

    public async Task<SpotDto> Handle(SpotGetByIdQuery request, CancellationToken cancellationToken)
    {
        var spot = await _spotRepository.GetByIdAsync(request.Id);
        var dto = _mapper.Map<SpotDto>(spot);
        return dto;
    }
}