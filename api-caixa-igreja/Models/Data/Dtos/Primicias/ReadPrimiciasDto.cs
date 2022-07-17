using System;

namespace api_caixa_igreja.Models.Data.Dtos.Primicias
{
    public class ReadPrimiciasDto
    {
        public int Id { get; set; }
        public DateTime Dia { get; set; }
        public string Periodo { get; set; }
        public double Valor { get; set; }
        public string MembroOfertante { get; set; }
        public string TipoOferta { get; set; }
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
