using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeCentral.Models
{
    public class Produto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
        
        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(0.01, 1000.00, ErrorMessage = "O preço deve estar entre R$ 0,01 e R$ 1.000,00")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Preco { get; set; }
        
        [StringLength(50, ErrorMessage = "A categoria deve ter no máximo 50 caracteres")]
        public string Categoria { get; set; }
        
        [StringLength(255, ErrorMessage = "A URL da imagem deve ter no máximo 255 caracteres")]
        public string? ImagemUrl { get; set; }
        
        [Display(Name = "Disponível")]
        public bool Disponivel { get; set; } = true;
    }
}