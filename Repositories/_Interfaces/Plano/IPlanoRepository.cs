using PlanSaleWithAddon.Entities;

namespace PlanSaleWithAddon.Repositories._Interfaces
{
    public interface IPlanoRepository : IBaseRepository<Plano>, IDisposable
    {

        IEnumerable<Plano> GetAllPlan();
        IEnumerable<Plano> GetPlanByAnual(bool anual);
        Plano GetPlanByPessoaEmail(Pessoa pessoa);
        Plano AddWithPessoa(Plano plano, Pessoa pessoa);

    }
}
