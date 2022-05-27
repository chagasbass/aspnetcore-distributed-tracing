namespace WorkerServiceUm.Entidades
{
    public class Produto
    {
        public Produto(string? nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }

        public Guid Id { get; set; }
        public string? Nome { get; set; }
    }
}
