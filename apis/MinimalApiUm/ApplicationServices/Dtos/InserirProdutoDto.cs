using Flunt.Notifications;
using Flunt.Validations;

namespace MinimalApiUm.ApplicationServices.Dtos
{
    public class InserirProdutoDto : Notifiable<Notification>
    {
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public Guid CategoriaId { get; set; }

        public InserirProdutoDto() { }

        public void ValidarProduto()
        {
            AddNotifications(new Contract<Notification>()
               .Requires()
               .AreNotEquals(CategoriaId, Guid.Empty, "A Categoria é inválida")
               .IsNotNullOrEmpty(Nome, nameof(Nome), "O nome é obrigatório.")
               .IsGreaterThan(Preco, 0, nameof(Preco), "O preço é inválido."));
        }
    }
}
