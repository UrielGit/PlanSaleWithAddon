using PlanSaleWithAddon.Entities.ValueObjects;

namespace PlanSaleWithAddon.Entities
{
    public class Plano
    {

        public int Id{ get; set; }
        public TipoPlano TipoPlano { get; set; } 
        public bool Anual { get; set; }
        public decimal ValorTotal { get; set; }


        #region Entidade Associativa

        //Propriedade virtual associativa 1:1
        public Pessoa Pessoa { get; set; }

        //Propriedade virtual associativa 1:N
        public List<Addon> Addons { get; set; }

        #endregion

        protected Plano() { }

        public Plano(int id, TipoPlano tipoPlano, bool anual, decimal valorTotal)
        {
            Id = id;
            TipoPlano = tipoPlano;
            Anual = anual;
            ValorTotal = valorTotal;
        }

        public Plano(TipoPlano tipoPlano, bool anual, decimal valorTotal)
        {
            TipoPlano = tipoPlano;
            Anual = anual;
            ValorTotal = valorTotal;
        }

        public void VincularAddons(List<Addon> addon)
        {
            if (addon.Any())
                Addons.AddRange(addon);
            else
                Addons = new List<Addon>();

        }

        public void VincularPessoa(Pessoa pessoa)
        {
            if (pessoa == null) return;

            pessoa.VincularPlano(Id);

            Pessoa = pessoa;
        }

    }
}
