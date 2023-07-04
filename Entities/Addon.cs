using PlanSaleWithAddon.Entities.ValueObjects;
using System.Drawing;

namespace PlanSaleWithAddon.Entities
{
    public class Addon
    {

        public int Id { get; set; }
        public TipoAddon TipoAddon { get; set; }
        public decimal Valor { get; set; }

        //Propriedade virtual associativa N:1
        public int PlanoId { get; set; }

        public virtual Plano Plano { get; set; }

        public Addon() { }

        public Addon(int id, TipoAddon tipoAddon, decimal valor)
        {
            Id = id;
            TipoAddon = tipoAddon;
            Valor = valor;
        }

        public Addon(TipoAddon tipoAddon, decimal valor)
        {
            TipoAddon = tipoAddon;
            Valor = valor;
        }

        public void Alterar(Addon addon)
        {
            TipoAddon = addon.TipoAddon;
            Valor = addon.Valor;
        }

    }

}
