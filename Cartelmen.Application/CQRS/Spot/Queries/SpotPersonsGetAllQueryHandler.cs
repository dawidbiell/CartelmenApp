using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Spot.Queries;

public class SpotPersonsGetAllQueryHandler(
    ISpotPersonsRepository repository,
    IMapper mapper)
    : IRequestHandler<SpotPersonsGetAllQuery, SpotPersonsDto?>
{
    public async Task<SpotPersonsDto?> Handle(SpotPersonsGetAllQuery request, CancellationToken ct)
    {
        var spot = await repository.AssignmentGetBySpotIdAsync(request.SpotId, ct);
        if (spot is null)  return null;
            
        var dto =  new SpotPersonsDto()
        {
            Spot = mapper.Map<SpotDto>(spot)
        };
            
        var personDtos = spot.Persons
            .Select(mapper.Map<PersonDto>)
            .ToList();

        dto.Persons = personDtos;
            
        return dto;
    }
}