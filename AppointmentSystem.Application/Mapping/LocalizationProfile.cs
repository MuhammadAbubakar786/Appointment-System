using AppointmentSystem.Core.DTOs;
using AutoMapper;

namespace AppointmentSystem.Application.Mapping
{
    public class LocalizationProfile : Profile
    {
        public LocalizationProfile()
        {
            CreateMap<Dictionary<string, string>, LoginFormLabelDTOs>()
          .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src["UserName"]))
          .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src["Email"]))
          .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src["Password"]))
          .ForMember(dest => dest.LoginPageHeadline, opt => opt.MapFrom(src => src["LoginPageHeadline"]));
        }
    }
}
