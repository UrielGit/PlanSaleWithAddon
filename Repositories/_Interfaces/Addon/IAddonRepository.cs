using PlanSaleWithAddon.Entities;
using PlanSaleWithAddon.Entities.ValueObjects;

namespace PlanSaleWithAddon.Repositories._Interfaces
{
    public interface IAddonRepository : IBaseRepository<Addon>, IDisposable
    {
        IEnumerable<Addon> GetAllByType(TipoAddon tipoAddon);
        IEnumerable<Addon> GetAllByPlan(int idPlan);

    }
}
