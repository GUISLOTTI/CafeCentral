using System.ComponentModel.DataAnnotations;

namespace CafeCentral.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O telefone é obrigatório")]
        [StringLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres")]
        public string Telefone { get; set; }
        
        [Required(ErrorMessage = "O endereço é obrigatório")]
        [StringLength(200, ErrorMessage = "O endereço deve ter no máximo 200 caracteres")]
        public string Endereco { get; set; }
        
        [Required(ErrorMessage = "A cidade é obrigatória")]
        [StringLength(100, ErrorMessage = "A cidade deve ter no máximo 100 caracteres")]
        public string Cidade { get; set; }
        
        [StringLength(100, ErrorMessage = "O complemento deve ter no máximo 100 caracteres")]
        public string? Complemento { get; set; }
        
        [Required(ErrorMessage = "O bairro é obrigatório")]
        [StringLength(100, ErrorMessage = "O bairro deve ter no máximo 100 caracteres")]
        public string Bairro { get; set; }
        
        [Required(ErrorMessage = "O estado é obrigatório")]
        [StringLength(2, ErrorMessage = "O estado deve ter 2 caracteres")]
        public string Estado { get; set; }
        
        public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}