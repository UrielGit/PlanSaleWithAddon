using PlanSaleWithAddon.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace PlanSaleWithAddon.ViewModels
{
    public class AddonViewModel
    {
        [Required]
        public TipoAddon TipoAddon { get; set; }
        [Required]
        public decimal Valor { get; set; }


    }
}
