using api_caixa_igreja.Models.Data.Dtos.Ofertas;
using api_caixa_igreja.Models.Entities;
using AutoMapper;

namespace api_caixa_igreja.Profiles
{
    public class OfertasProfile : Profile
    {
        public OfertasProfile()
        {
            CreateMap<CreateOfertasDto, Ofertas>();
            //CreateMap<Ofertas, ReadOfertasDto>();
            CreateMap<Ofertas, ReadOfertasDto>()
                .ForMember(dest => dest.MembroMinistrante, map => 
                map.MapFrom(src => src.MembroMinistrante.Nome))
                .ForMember(dest => dest.MembroOfertante, map =>
                map.MapFrom(src => src.MembroOfertante.Nome))
                .ForMember(dest => dest.TipoOferta, map =>
                map.MapFrom(src => src.TipoOferta.Nome))
                .ForMember(dest => dest.TipoCulto, map => 
                map.MapFrom(src => src.TipoCulto.Nome));
        }
    }
}
