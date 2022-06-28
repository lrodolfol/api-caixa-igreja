using System;
using System.ComponentModel.DataAnnotations;

namespace api_caixa_igreja.Models.Entities
{
    public class Dizimos
    {
        [Key]
        [Required(ErrorMessage = "Id obrigátorio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Dia: Dia da oferta é obrigatório")]
        public DateTime Dia { get; set; }
        [Required(ErrorMessage = "Periodo: Mes/Ano do dizimo é obrigatório")]
        public string Periodo { get; set; }
        [Required(ErrorMessage = "Valor: Valor do dizimo é obrigatório")]
        [Range(typeof(Decimal), "0", "9999999999", ErrorMessage = "Valor: valor do dizimo não pode ser menor/igual a 0")]
        public double Valor { get; set; }
        [Required(ErrorMessage = "IdMembroDizimista: Id do membro dizimista obrigatório")]
        public int IdMembroDizimista { get; set; }
        public virtual Membros MembroDizimista { get; set; }
    }
}
