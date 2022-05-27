using System.Text.Json.Serialization;

namespace MinimalApiUm.Domain.Entities
{
    public class Categoria
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        public Categoria(string? nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }
    }
}
