namespace CafeCentral.Models
{
    public class CarrinhoItem
    {
        public int ProdutoId { get; set; }
        public required string Nome { get; set; }
        public required decimal Preco { get; set; }
        public required int Quantidade { get; set; }
        public required string ImagemUrl { get; set; }
        public decimal Subtotal => Preco * Quantidade;
    }
}