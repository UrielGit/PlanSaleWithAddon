using Microsoft.EntityFrameworkCore;
using PlanSaleWithAddon.EFCore.Context;
using PlanSaleWithAddon.Entities.ValueObjects;
using PlanSaleWithAddon.Repositories._Interfaces;

namespace PlanSaleWithAddon.Repositories
{
    public class PessoaRepository : BaseRepository<Entities.Pessoa>, IPessoaRepository
    {

        public PessoaRepository(AppDbContext dbContext) : base(dbContext) { }

        public IEnumerable<Entities.Pessoa> GetAllByTipoPlano(TipoPlano tipoPlano)
        {

            return _dbSet.Where(x => x.Plano.TipoPlano == tipoPlano).ToList(); 
        }

        public Entities.Pessoa GetByEmail(string email)
        {
            return _dbSet.FirstOrDefault(x => x.Email == email) ?? throw new Exception("Não existem pessoas cadastradas com este email.");
        }

        public Entities.Pessoa GetByIdWithPlano(int id)
        {
            return _dbSet
                .Include(x => x.Plano)
                .FirstOrDefault(x => x.Id == id) ?? throw new Exception("Não existem pessoas cadastradas a este plano.");
        }
    }
}
