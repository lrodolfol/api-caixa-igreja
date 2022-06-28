using api_caixa_igreja.Models.Data.Dtos.Dizimos;
using api_caixa_igreja.Models.Entities;
using AutoMapper;

namespace api_caixa_igreja.Profiles
{
    public class DizimoProfile : Profile
    {
        public DizimoProfile()
        {
            CreateMap<CreateDizimosDto, Dizimos>();
            CreateMap<Dizimos, ReadDizimosDto>()
                .ForMember(dest => dest.MembroDizimista, map =>
                map.MapFrom(src => src.MembroDizimista.Nome));
        }
    }
}
