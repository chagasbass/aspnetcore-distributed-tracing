namespace WorkerServiceUm.Entidades
{
    public class Produto
    {
        public Produto(string? nome)
        {
            Guid id = Guid.NewGuid();
            Nome = nome;
        }

        public Guid Id { get; set; }
        public string? Nome { get; set; }
    }
}
