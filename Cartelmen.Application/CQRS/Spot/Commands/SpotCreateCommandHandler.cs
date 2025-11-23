using AutoMapper;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Spot.Commands;

public class SpotCreateCommandHandler(
    IMapper mapper,
    ISpotRepository repository)
    : IRequestHandler<SpotCreateCommand, int>
{

    public async Task<int> Handle(SpotCreateCommand request, CancellationToken cancellationToken)
    {
        // Validation DTO by DataAnnotations
        var spot = mapper.Map<Domain.Entities.Spot>(request);
        await repository.AddAsync(spot);
        return spot.Id;
    }
}
