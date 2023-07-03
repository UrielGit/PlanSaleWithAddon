using System.ComponentModel.DataAnnotations;

namespace PlanSaleWithAddon.ViewModels
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Nome do usuário não informado.")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email não informado.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha não informado.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Senha não informado.")]
        [Compare("Password", ErrorMessage = "As senhas informadas não conferem")]
        public string? ConfirmPassword { get; set; }

    }

}
