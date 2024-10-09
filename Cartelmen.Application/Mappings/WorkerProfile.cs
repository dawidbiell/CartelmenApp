using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Entities;

namespace Cartelmen.Application.Mappings;
public class WorkerProfile : Profile
{
    public WorkerProfile()
    {
        CreateMap<WorkerDto, Worker>()
            .ForMember(w => w.Contact, 
                cd => cd.MapFrom(src => new ContactDetails()
                {
                    Email = src.Email,
                    Phone = src.Phone,
                }))
            .ForMember(e => e.PayRate, src => src.MapFrom(src => src.PayRate));
        // rest of members are automapped
    }
}
