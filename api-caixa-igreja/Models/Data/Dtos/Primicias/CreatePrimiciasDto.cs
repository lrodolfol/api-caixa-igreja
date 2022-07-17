using System;
using System.ComponentModel.DataAnnotations;

namespace api_caixa_igreja.Models.Data.Dtos.Primicias
{
    public class CreatePrimiciasDto
    {
        [Required(ErrorMessage = "Dia: Dia da primícia é obrigatório")]
        public DateTime Dia { get; set; }
        [Required(ErrorMessage = "Periodo: Mes/Ano da primícia é obrigatório")]
        public string Periodo { get; set; }
        [Required(ErrorMessage = "Valor: Valor é obrigatório")]
        [Range(0.1, 9999999999, ErrorMessage = "Valor: valor não pode ser menor/igual a 0")]
        public double Valor { get; set; }
        [Required(ErrorMessage = "IdMembro: Id do membro é obrigatório")]
        public int IdMembro { get; set; }
        public int IdTipoOferta { get; set; }
    }
}
