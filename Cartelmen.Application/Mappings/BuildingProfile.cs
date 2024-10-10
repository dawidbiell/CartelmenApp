using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Entities;

namespace Cartelmen.Application.Mappings;
public class BuildingProfile:Profile
{
    public BuildingProfile()
    {
        CreateMap<BuildingDto, Building>()
            .ForMember(dto => dto.Address, opt => opt
                .MapFrom(dto => new Address()
                {
                    Country = dto.Country,
                    City = dto.City,
                    Street = dto.Street,
                    PostalCode = dto.PostalCode
                }));

        // rest of members are automapped by Type+name
    }
}
