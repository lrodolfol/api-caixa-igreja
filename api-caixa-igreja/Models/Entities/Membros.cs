using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_caixa_igreja.Models.Entities
{
    public class Membros
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "ID: campo é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Nome: Data de nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }
        public int CargoId { get; set; }
        public virtual Cargos Cargo { get; set; }
       [JsonIgnore]
        public virtual List<Ofertas> OfertasMinistradas { get; set; }
        [JsonIgnore]
        public virtual List<Ofertas> OfertasRealizadas { get; set; }
    }
}