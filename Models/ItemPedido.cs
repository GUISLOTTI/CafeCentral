using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeCentral.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }

        public int PedidoId { get; set; }

        public int ProdutoId { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "A quantidade deve estar entre 1 e 100")]
        public required int Quantidade { get; set; } = 1;

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public required decimal Subtotal { get; set; }

        
        public virtual Pedido? Pedido { get; set; }
        public virtual Produto? Produto { get; set; }
    }
}