namespace MinimalApiDois.Domain.Entities
{
    public class Categoria
    {
        public Categoria(Guid id, string? nome)
        {
            Id = id;
            Nome = nome;
        }

        public Guid Id { get; set; }
        public string? Nome { get; set; }
    }
}
