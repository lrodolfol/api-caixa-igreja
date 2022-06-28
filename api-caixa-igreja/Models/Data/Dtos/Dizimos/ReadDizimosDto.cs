using System;

namespace api_caixa_igreja.Models.Data.Dtos.Dizimos
{
    public class ReadDizimosDto
    {
        public int Id { get; set; }
        public DateTime Dia { get; set; }
        public string Periodo { get; set; }
        public double Valor { get; set; }
        public string MembroDizimista { get; set; }
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
