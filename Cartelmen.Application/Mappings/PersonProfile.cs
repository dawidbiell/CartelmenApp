using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Entities;

namespace Cartelmen.Application.Mappings;
public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<PersonDto, Person>()
            .ForMember(e => e.Contact, 
                cd => cd.MapFrom(dto => new ContactDetails()
                {
                    Email = dto.Email,
                    Phone = dto.Phone,
                }))
            .ForMember(e => e.PayRate, pr => pr.MapFrom(dto => dto.PayRate));
        // rest of members are automapped by Type+name

        CreateMap<Person, PersonDto>()
            .ForMember(dto => dto.Email, opt => opt.MapFrom(src => src.Contact.Email))
            .ForMember(dto => dto.Phone, opt => opt.MapFrom(src => src.Contact.Phone));

    }
}
