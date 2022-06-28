using System;
using System.ComponentModel.DataAnnotations;

namespace api_caixa_igreja.Models.Data.Dtos.Membros
{
    public class CreateMembrosDto
    {
        [Required(ErrorMessage = "Nome: campo é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Nome: Data de nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }
        public int CargoId { get; set; }
    }
}
