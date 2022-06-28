using api_caixa_igreja.Models.Data.Dtos.TipoOferta;
using api_caixa_igreja.Models.Entities;
using AutoMapper;

namespace api_caixa_igreja.Profiles
{
    public class TipoOfertaProfile : Profile
    {
        public TipoOfertaProfile()
        {
            CreateMap<CreateTipoOfertaDto, TipoOferta>();
            CreateMap<TipoOferta, ReadTipoOfertaDto>();
        }
    }
}
