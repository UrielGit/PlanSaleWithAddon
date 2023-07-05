using PlanSaleWithAddon.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace PlanSaleWithAddon.ViewModels
{
    public class PlanoViewModel
    {
        // Tipo de plano 1/2/3 - Arcade/Advanced/Pro 
        [Required]
        public string TipoPlano { get; set; }

        // Se é anual - bool
        [Required]
        public bool Anual { get; set; }

        // Valor total do plano (me envia só o valor do plano que eu somo com os do addon)
        [Required]
        public decimal ValorTotal { get; set; }

        // Nome da pessoa
        [Required]
        public string Nome { get; set; }

        // Email da pessoa
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        [RegularExpression(@"^\(\d{2}\) \d{5}-\d{4}$", ErrorMessage = "O formato do telefone deve ser no formato (DDD) 99999-9999.")]
        public string Telefone { get; set; }

        // Associação
        //public PessoaViewModel Pessoa { get; set; }

        public string[]? AddonsBuy { get; set; }
        public List<AddonViewModel>? Addons { get; set; }

    }
}
