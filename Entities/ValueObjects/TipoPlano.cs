using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PlanSaleWithAddon.Entities.ValueObjects
{
    public enum TipoPlano
    {
        [Display(Name = "Arcade")]
        [Description("Arcade")]
        Arcade = 1,

        [Display(Name = "Advanced")]
        [Description("Advanced")]
        Advanced = 2,

        [Display(Name = "Pro")]
        [Description("Pro")]
        Pro = 3,

    }
}
