using api_caixa_igreja.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace api_caixa_igreja.Models.Entities
{
    public class Lancamentos
    {
        [Key]
        [Required(ErrorMessage = "Id obrigátorio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tipo: Tipo da mov é obrigatório (credito/debito)")]
        public TipoMovimentacao Tipo { get; set; }
        [Required(ErrorMessage = "Descrição: Decrição é obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "tabelaOrigem: nome da tabela de origem é obrigatório")]
        public string tabelaOrigem { get; set; }
        [Required(ErrorMessage = "IdTabelaOrigem: Id do campo da tabela origem é obrigatório")]
        public int IdTabelaOrigem { get; set; }
        [Required(ErrorMessage = "Valor: Valor em R$ é obrigatório")]
        public double Valor { get; set; }
        [Required(ErrorMessage = "Dia: dia é obrigatório")]
        public DateTime Dia { get; set; }
    }
}
