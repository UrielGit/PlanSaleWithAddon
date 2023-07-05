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
        public virtual Pessoa Pessoa { get; set; }

        //Propriedade virtual associativa 1:N
        public virtual List<Addon> Addons { get; set; }

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
            valorTotal = CalculaValorTotalPlano(tipoPlano, anual);

            TipoPlano = tipoPlano;
            Anual = anual;
            ValorTotal = valorTotal;
        }

        public void Alterar(Plano plano)
        {
            TipoPlano = plano.TipoPlano;
            Anual = plano.Anual;
            ValorTotal = plano.ValorTotal;

            VincularAddons(plano.Addons);

            VincularPessoa(plano.Pessoa);
        }

        public void VincularAddons(List<Addon> addon)
        {
            if (!addon.Any()) return;

            if (Addons == null)
                Addons = new List<Addon>();

            Addons.AddRange(addon);

        }

        public void VincularPessoa(Pessoa pessoa)
        {
            if (pessoa == null) return;

            pessoa.VincularPlano(Id);

            Pessoa = pessoa;
        }

        public decimal CalculaValorTotalPlano(TipoPlano tipoPlano, bool anual)
        {
            var valorPlano = 0M;

            switch (tipoPlano)
            {
                case TipoPlano.Arcade:
                    valorPlano = 4.86M * 9;
                    break;
                case TipoPlano.Advanced:
                    valorPlano = 4.86M * 12;
                    break;
                case TipoPlano.Pro:
                    valorPlano = 4.86M * 15;
                    break;
            }

            return anual ? valorPlano * 12 : valorPlano;
        }

    }
}
