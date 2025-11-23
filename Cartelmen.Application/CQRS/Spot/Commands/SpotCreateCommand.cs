using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Spot.Commands;

public class SpotCreateCommand : SpotDto , IRequest<int>
{
    
}