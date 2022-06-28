using api_caixa_igreja.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api_caixa_igreja.Models.Data.Dtos.Cargos
{
    public class ReadCargosDto
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
