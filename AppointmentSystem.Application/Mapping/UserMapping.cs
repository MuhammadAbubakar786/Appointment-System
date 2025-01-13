using AppointmentSystem.Application.Command.Model;
using AppointmentSystem.Core.Entities;
using AutoMapper;

namespace AppointmentSystem.Application.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<EditUserCommand, UserEntity>()
             .ForMember(d => d.UserEmail, opt => opt.MapFrom(src => src.Email))
             .ForMember(d => d.PhoneNumber, opt =>
             {
                 opt.PreCondition(src => src.PhoneNumber != null); // Ensure PhoneNumber is not null
                 opt.MapFrom(src => src.PhoneNumber);
             }).ReverseMap();
        }
    }
}
