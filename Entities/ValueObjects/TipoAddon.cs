using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;

namespace PlanSaleWithAddon.Entities.ValueObjects
{
    public enum TipoAddon
    {
        [Display(Name = "Online Service")]
        [Description("Online Service")]
        OnlineService = 1,

        [Display(Name = "Larger Storage")]
        [Description("Larger Storage")]
        LargerStorage = 2,

        [Display(Name = "Customizable Profile")]
        [Description("Customizable Profile")]
        CustomizableProfile = 3,

    }
}
