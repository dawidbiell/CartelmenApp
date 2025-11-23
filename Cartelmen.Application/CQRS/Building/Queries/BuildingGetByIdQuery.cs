using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Building.Queries;

public class BuildingGetByIdQuery(int id) :  IRequest<BuildingDto>
{
    public int Id { get; } = id;
}