using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Entities;

namespace Cartelmen.Application.Mappings;
public class WorkerProfile : Profile
{
    public WorkerProfile()
    {
        CreateMap<WorkerDto, Worker>()
            .ForMember(e => e.Contact, 
                cd => cd.MapFrom(dto => new ContactDetails()
                {
                    Email = dto.Email,
                    Phone = dto.Phone,
                }))
            .ForMember(e => e.PayRate, pr => pr.MapFrom(dto => dto.PayRate));
        // rest of members are automapped by Type+name

        CreateMap<Worker, WorkerDto>()
            .ForMember(dto => dto.Email, opt => opt.MapFrom(src => src.Contact.Email))
            .ForMember(dto => dto.Phone, opt => opt.MapFrom(src => src.Contact.Phone));

    }
}
