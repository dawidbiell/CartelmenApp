using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Entities;

namespace Cartelmen.Application.Mappings;
public class BuildingProfile:Profile
{
    public BuildingProfile()
    {
        CreateMap<SpotDto, Spot>(  )
            .ForMember(e => e.Address, a => a
                .MapFrom(dto => new Address()
                {
                    Country = dto.Country,
                    City = dto.City,
                    Street = dto.Street,
                    PostalCode = dto.PostalCode
                }));

        // rest of members are automapped by Type+name

        CreateMap<Spot, SpotDto>()
            .ForMember(dto => dto.Country, opt => opt.MapFrom(src => src.Address.Country))
            .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode))
            .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.Address.Street));
    }
}
