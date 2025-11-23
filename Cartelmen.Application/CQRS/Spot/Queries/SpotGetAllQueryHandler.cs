using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Spot.Queries;

public class SpotGetAllQueryHandler:  IRequestHandler<SpotGetAllQuery, IEnumerable<SpotDto>>
{
    private readonly ISpotRepository  _repository;
    private readonly IMapper _mapper;

    public SpotGetAllQueryHandler(ISpotRepository  spotRepository, IMapper mapper)
    {
        _repository = spotRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<SpotDto>> Handle(SpotGetAllQuery request, CancellationToken cancellationToken)
    {
        var spots = await _repository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<SpotDto>>(spots);
        return dtos;
    }
}