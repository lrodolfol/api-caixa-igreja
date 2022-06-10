using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace api_caixa_igreja.Models.Entities
{
    public class Membros
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome: campo é obrigatório")]  
        public string  Nome { get; set; }
        [Required(ErrorMessage = "Nome: Data de nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }
        public int CargoId { get; set; }
        public virtual Cargos Cargo { get; set; }
    }

    public class MembrosUpdateCto : Profile
    {
        public string Nome { get; set; }
        [Required(ErrorMessage = "Nome: Data de nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }
        public int CargoId { get; set; }
    }

    public class MapperMembros : Profile
    {
        public MapperMembros()
        {
            CreateMap<MembrosUpdateCto, Membros>();
        }
    }
}
