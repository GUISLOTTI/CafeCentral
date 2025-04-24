using System.ComponentModel.DataAnnotations;

namespace CafeCentral.Models.ViewModels
{
    public class PedidoViewModel
    {
        // Dados do Cliente
        [Required(ErrorMessage = "O nome é obrigatório")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
        
        // Endereço de Entrega
        [Required(ErrorMessage = "O endereço é obrigatório")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        
        [Required(ErrorMessage = "A cidade é obrigatória")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }
        
        [Display(Name = "Complemento")]
        public string? Complemento { get; set; }
        
        [Required(ErrorMessage = "O bairro é obrigatório")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }
        
        [Required(ErrorMessage = "O estado é obrigatório")]
        [StringLength(2, ErrorMessage = "O estado deve ter 2 caracteres")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }
        
        // Pagamento
        [Required(ErrorMessage = "A forma de pagamento é obrigatória")]
        [Display(Name = "Forma de Pagamento")]
        public string FormaPagamento { get; set; }
    }
}