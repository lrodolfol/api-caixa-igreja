using System;
using System.ComponentModel.DataAnnotations;

namespace api_caixa_igreja.Models.Data.Dtos.Membros
{
    public class ReadMembrosDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        //public int CargoId { get; set; }
        public virtual Entities.Cargos Cargo { get; set; }
        public DateTime DataBatismo { get; set; }
        public DateTime DateRequest
        {
            get
            {
                DateTime h = DateTime.Now;
                return h;
            }
        }

    }
}
