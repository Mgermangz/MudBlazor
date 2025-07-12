using AutoMapper;
using Mggz.Shared.DTOs.Oficiales;
using Mggz.Shared.Entidades.Oficiales;

namespace Mggz.Shared.Utilidades;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateMap<Source, Destination>();
        CreateMap<PaisDtoNew, Pais>().ReverseMap();
        CreateMap<PaisDto, Pais>()
                 .ForMember(dest => dest.PaisId, opt => opt.MapFrom(src => src.Id))
                 .ReverseMap();
    }
}
