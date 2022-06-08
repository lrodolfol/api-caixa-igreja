using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_caixa_igreja.Models.Entities
{
    public class Cargos
    {
        [Key]
        [Required(ErrorMessage = "Id obrigátorio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome: campo é obrigátorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Descrição: campo é obrigátorio")]
        public string Descricao { get; set; }
        public virtual List<Membros> Membros { get; set; }
    }
}
