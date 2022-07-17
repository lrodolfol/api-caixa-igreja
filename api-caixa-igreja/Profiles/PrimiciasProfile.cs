
using api_caixa_igreja.Models.Data.Dtos.Primicias;
using api_caixa_igreja.Models.Entities;
using AutoMapper;

namespace api_caixa_igreja.Profiles
{
    public class PrimiciasProfile : Profile
    {
        public PrimiciasProfile()
        {
            CreateMap<CreatePrimiciasDto, Primicias>();
            CreateMap<Primicias, ReadPrimiciasDto>()
                .ForMember(dest => dest.MembroOfertante, map =>
                map.MapFrom(src => src.Membro.Nome))
                .ForMember(dest => dest.TipoOferta, map => 
                map.MapFrom(src => src.TipoOferta.Nome));
        }
    }
}
