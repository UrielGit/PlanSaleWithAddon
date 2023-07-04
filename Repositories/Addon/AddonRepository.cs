using Microsoft.EntityFrameworkCore;
using PlanSaleWithAddon.EFCore.Context;
using PlanSaleWithAddon.Entities;
using PlanSaleWithAddon.Entities.ValueObjects;
using PlanSaleWithAddon.Repositories._Interfaces;

namespace PlanSaleWithAddon.Repositories
{
    public class AddonRepository : BaseRepository<Addon>, IAddonRepository
    {

        public AddonRepository(AppDbContext dbContext) : base(dbContext) { }

        public IEnumerable<Addon> GetAllByPlan(int idPlan)
        {

            return _dbSet.Where(x => x.PlanoId == idPlan);

        }

        public IEnumerable<Addon> GetAllByType(TipoAddon tipoAddon)
        {
            return _dbSet.Where(x => x.TipoAddon == tipoAddon);
        }

    }
}
