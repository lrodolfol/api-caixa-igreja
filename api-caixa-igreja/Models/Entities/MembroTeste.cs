using System.Text.Json.Serialization;

namespace api_caixa_igreja.Models.Entities
{
    public class MembroTeste
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string name { get; set; }
    }
}
