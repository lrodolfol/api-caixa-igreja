using System;

namespace api_caixa_igreja.Models.Data.Dtos.Ofertas
{
    public class ReadOfertasDto
    {
        public int Id { get; set; }
        public DateTime Dia { get; set; }
        public int QtdAdultos { get; set; }
        public int QtdCriancas { get; set; }
        public double totalOferta { get; set; }
        public string TipoCulto { get; set; }
        public string TipoOferta { get; set; }
        public string MembroMinistrante { get; set; }
        public string MembroOfertante { get; set; }
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
