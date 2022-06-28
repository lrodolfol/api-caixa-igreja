using api_caixa_igreja.Models.Data.Dtos.TipoCulto;
using api_caixa_igreja.Models.Data.Dtos.TipoOferta;
using api_caixa_igreja.Models.Entities;
using AutoMapper;

namespace api_caixa_igreja.Profiles
{
    public class TipoCultoProfile : Profile
    {
        public TipoCultoProfile()
        {
            CreateMap<CreateTipoCultoDto, TipoCulto>();
            CreateMap<TipoCulto, ReadTipoCultoDto>();
        }
    }
}
