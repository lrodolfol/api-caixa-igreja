using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_caixa_igreja.Models.Entities
{
    public class Ofertas
    {
        [Key]
        [Required(ErrorMessage = "Id obrigátorio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Dia: Dia da oferta é obrigatório")]
        public DateTime Dia { get; set; }
        [Required(ErrorMessage = "qtdAdultos: Quantidade de adultos é obrigatório")]
        public int QtdAdultos { get; set; }
        [Required(ErrorMessage = "qtdCriancas: Quantidade de crianças é obrigatório")]
        public int QtdCriancas { get; set; }
        [Required(ErrorMessage = "totalOferta: total de ofertas em R$ é obrigatório")]
        public double totalOferta { get; set; }
        [Required(ErrorMessage = "IdTipoCulto: Tipo do culto é obrigatório")]
        public int IdTipoCulto { get; set; }
        [Required(ErrorMessage = "IdTipoOferta: Tipo de oferta é obrigatório")]
        public int IdTipoOferta { get; set; }
        [Required(ErrorMessage = "IdMembroMinistrante: Ministrante da oferta é obrigatório")]
        public int IdMembroMinistrante { get; set; }
        public int IdMembroOfertante { get; set; } = 0;
        
        public virtual TipoCulto TipoCulto { get; set; }
        public virtual TipoOfertas TipoOferta { get; set; }
        public virtual Membros MembroMinistrante { get; set; }
        public virtual Membros MembroOfertante { get; set; }
    }
}
