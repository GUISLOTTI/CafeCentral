using System.ComponentModel.DataAnnotations;

namespace CafeCentral.Models.ViewModels
{
    public class PedidoViewModel
    {
        // Dados do Cliente
        [Required(ErrorMessage = "O nome é obrigatório")]
        [Display(Name = "Nome")]
        public required string Nome { get; set; }
        
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Display(Name = "E-mail")]
        public required string Email { get; set; }
        
        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Display(Name = "Telefone")]
        public required string Telefone { get; set; }
        
        // Endereço de Entrega
        [Required(ErrorMessage = "O endereço é obrigatório")]
        [Display(Name = "Endereço")]
        public required string Endereco { get; set; }
        
        [Required(ErrorMessage = "A cidade é obrigatória")]
        [Display(Name = "Cidade")]
        public required string Cidade { get; set; }
        
        [Display(Name = "Complemento")]
        public string? Complemento { get; set; }
        
        [Required(ErrorMessage = "O bairro é obrigatório")]
        [Display(Name = "Bairro")]
        public required string Bairro { get; set; }
        
        [Required(ErrorMessage = "O estado é obrigatório")]
        [StringLength(2, ErrorMessage = "O estado deve ter 2 caracteres")]
        [Display(Name = "Estado")]
        public required string Estado { get; set; }
        
        // Pagamento
        [Required(ErrorMessage = "A forma de pagamento é obrigatória")]
        [Display(Name = "Forma de Pagamento")]
        public required string FormaPagamento { get; set; }
    }
}