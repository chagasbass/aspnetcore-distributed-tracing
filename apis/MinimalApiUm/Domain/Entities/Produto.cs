namespace MinimalApiUm.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public Guid CategoriaId { get; set; }
        public string? NomeCategoria { get; set; }

        protected Produto() { }

        public Produto(string? nome, decimal preco, Guid categoriaId, string? nomeCategoria)
        {
            Nome = nome;
            Preco = preco;
            CategoriaId = categoriaId;
            NomeCategoria = nomeCategoria;
        }
    }
}
