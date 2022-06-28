using System.ComponentModel.DataAnnotations;

namespace api_caixa_igreja.Models.Data.Dtos.Cargos
{
    public class CreateCargosDto
    {
        [Key]
        [Required(ErrorMessage = "Id obrigátorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Descrição: campo é obrigátorio")]
        public string Descricao { get; set; }
    }
}
