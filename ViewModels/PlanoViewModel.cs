using PlanSaleWithAddon.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace PlanSaleWithAddon.ViewModels
{
    public class PlanoViewModel
    {
        [Required]
        public TipoPlano TipoPlano { get; set; }
        [Required]
        public bool Anual { get; set; }
        [Required]
        public decimal ValorTotal { get; set; }

        // Associação
        public PessoaViewModel Pessoa { get; set; }

        public List<AddonViewModel> Addons { get; set; }

    }
}
