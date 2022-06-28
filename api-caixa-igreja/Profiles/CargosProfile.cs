using api_caixa_igreja.Models.Data.Dtos.Cargos;
using api_caixa_igreja.Models.Entities;
using AutoMapper;

namespace api_caixa_igreja.Profiles
{
    public class CargosProfile : Profile
    {
        public CargosProfile()
        {
            CreateMap<CreateCargosDto, Cargos>();
            CreateMap<Cargos, ReadCargosDto>();
        }
    }
}
