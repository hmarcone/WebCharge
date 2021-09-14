using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.AutoMapper
{
    public class PersonPhoneProfile : Profile
    {
        public PersonPhoneProfile()
        {
            CreateMap<PersonPhone, PersonPhoneDto>()
                .ReverseMap()
                .ForMember(dest => dest.BusinessEntityId, opt => opt.MapFrom(src => src.BusinessEntityId))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.PhoneNumberTypeId, opt => opt.MapFrom(src => src.PhoneNumberTypeId));
        }
    }
}
