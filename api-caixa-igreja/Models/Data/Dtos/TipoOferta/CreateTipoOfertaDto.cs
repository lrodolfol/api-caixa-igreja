using System.ComponentModel.DataAnnotations;

namespace api_caixa_igreja.Models.Data.Dtos.TipoOferta
{
    public class CreateTipoOfertaDto
    {
        [Required(ErrorMessage = "Nome: campo é obrigátorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Descrição: campo é obrigátorio")]
        public string Descricao { get; set; }
    }
}
