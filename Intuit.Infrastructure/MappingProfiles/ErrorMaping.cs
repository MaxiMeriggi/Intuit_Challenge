using AutoMapper;
using Intuit.Domain.Entities;
using Intuit.Infrastructure.Models;

namespace Intuit.Infrastructure.MappingProfiles
{
    public class ErrorProfile : Profile
    {
        public ErrorProfile()
        {
            CreateMap<Errores, Error>()

                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (int)src.Id))
                .ForMember(dest => dest.Module, opt => opt.MapFrom(src => src.Modulo))
                .ForMember(dest => dest.ErrorText, opt => opt.MapFrom(src => src.TextoError))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Fecha));
        }
    }

}
