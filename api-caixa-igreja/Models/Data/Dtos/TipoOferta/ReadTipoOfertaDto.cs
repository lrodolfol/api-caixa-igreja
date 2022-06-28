using System;

namespace api_caixa_igreja.Models.Data.Dtos.TipoOferta
{
    public class ReadTipoOfertaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
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
