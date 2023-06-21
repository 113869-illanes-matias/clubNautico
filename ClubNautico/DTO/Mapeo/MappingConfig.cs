using AutoMapper;
using ClubNautico.Models;
using ClubNautico.Services.Socios.Commands;

namespace ClubNautico.DTO.Mapeo
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Socio, SocioDTO>() //TODO: MAPEAMOS EL SOCIO CON EL DTO
                .ForMember(dest => dest.NombreCompleto, //TODO: MAPEAMOS EL NOMBRE COMPLETO
                opt => opt.MapFrom(src => src.Nombre + " " + src.Apellido)) //TODO: CONCATENAMOS EL NOMBRE Y EL APELLIDO
                .ReverseMap(); //TODO: MAPEAMOS EL DTO CON EL SOCIO

            CreateMap<SaveSocio, Socio>(); //TODO: MAPEAMOS EL SAVE SOCIO CON EL SOCIO

        }
      
    }
}
