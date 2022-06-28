using api_caixa_igreja.Models.Data.Dtos.Membros;
using api_caixa_igreja.Models.Entities;
using AutoMapper;
using System.Linq;

namespace api_caixa_igreja.Profiles
{
    public class MembroProfile : Profile
    {
        public MembroProfile()
        {
            CreateMap<CreateMembrosDto, Membros>();
            CreateMap<Membros, ReadMembrosDto>();
        }
    }
}
