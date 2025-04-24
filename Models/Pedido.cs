using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeCentral.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        
        public int ClienteId { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data do Pedido")]
        public DateTime DataPedido { get; set; } = DateTime.Now;
        
        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pendente";
        
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Valor Total")]
        public decimal ValorTotal { get; set; }
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Forma de Pagamento")]
        public string FormaPagamento { get; set; }
        
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();
    }
}