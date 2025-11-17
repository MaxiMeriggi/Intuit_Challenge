using AutoMapper;
using Intuit.Domain.Entities;
using Intuit.Infrastructure.Models;

namespace Intuit.Infrastructure.MappingProfiles
{
    public class ClientMapping : Profile
    {
        public ClientMapping()
        {
            CreateMap<Clientes, Client>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Nombre))
                .ForMember(
                    dest => dest.Surname,
                    opt => opt.MapFrom(src => src.Apellido))
                .ForMember(
                    dest => dest.CompanyName,
                    opt => opt.MapFrom(src => src.RazonSocial))
                .ForMember(
                    dest => dest.Cuit,
                    opt => opt.MapFrom(src => src.Cuit))
                .ForMember(
                    dest => dest.BirthDate,
                    opt => opt.MapFrom(src => src.FechaNacimiento))
                .ForMember(
                    dest => dest.Cellphone,
                    opt => opt.MapFrom(src => src.TelefonoCelular))
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(
                    dest => dest.CreationDate,
                    opt => opt.MapFrom(src => src.FechaCreacion))
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(src => src.FechaModificacion))
                .ReverseMap();
        }

    }
}
