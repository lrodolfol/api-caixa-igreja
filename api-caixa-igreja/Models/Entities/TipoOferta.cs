using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_caixa_igreja.Models.Entities
{
    public class TipoOferta
    {
        [Key]
        [Required(ErrorMessage = "Id obrigátorio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome: campo é obrigátorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Descrição: campo é obrigátorio")]
        public string Descricao { get; set; }
        [JsonIgnore]
        public virtual List<Ofertas> OfertasAlcadas { get; set; }
    }
}
