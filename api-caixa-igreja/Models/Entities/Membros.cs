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
}
