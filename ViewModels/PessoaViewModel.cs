using System.ComponentModel.DataAnnotations;

namespace PlanSaleWithAddon.ViewModels
{
    public class PessoaViewModel
    {

        [Required]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        [RegularExpression(@"^\(\d{2}\) \d{5}-\d{4}$", ErrorMessage = "O formato do telefone deve ser no formato (DDD) 99999-9999.")]
        public string Telefone { get; set; }

    }
}
