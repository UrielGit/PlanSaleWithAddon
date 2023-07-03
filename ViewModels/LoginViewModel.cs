using System.ComponentModel.DataAnnotations;

namespace PlanSaleWithAddon.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Nome do usuário não informado.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Senha não informado.")]
        public string? Password { get; set; }

    }
}
