using PlanSaleWithAddon.Entities;
using PlanSaleWithAddon.Entities.ValueObjects;

namespace PlanSaleWithAddon.Repositories._Interfaces
{
    public interface IPessoaRepository : IBaseRepository<Pessoa>, IDisposable
    {

        IEnumerable<Pessoa> GetAllByTipoPlano(TipoPlano tipoPlano);
        Pessoa GetByEmail(string email);
        Pessoa GetByIdWithPlano(int id);

    }
}
