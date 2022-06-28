using System;
using System.ComponentModel.DataAnnotations;

namespace api_caixa_igreja.Models.Data.Dtos.Ofertas
{
    public class CreateOfertasDto
    {
        public DateTime Dia { get; set; }
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
    }
}
