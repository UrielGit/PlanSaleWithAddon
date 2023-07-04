using Microsoft.EntityFrameworkCore;
using PlanSaleWithAddon.EFCore.Context;
using PlanSaleWithAddon.Entities;
using PlanSaleWithAddon.Repositories._Interfaces;

namespace PlanSaleWithAddon.Repositories
{
    public class PlanoRepository : BaseRepository<Plano>, IPlanoRepository
    {
      
        private readonly IPessoaRepository _pessoaRepository;

        public PlanoRepository(AppDbContext context, IPessoaRepository pessoaRepository) : base(context)
        {
            _pessoaRepository = pessoaRepository;
        }

        public Plano AddWithPessoa(Plano plano, Pessoa pessoa)
        {
            
            _appDbContext.Add(plano);

            plano.VincularPessoa(pessoa);

            _appDbContext.SaveChanges();

            return plano;

        }

        public IEnumerable<Plano> GetAllPlan()
        {
            return _dbSet
                .Include(x => x.Addons)
                .ToList();
        }

        public IEnumerable<Plano> GetPlanByAnual(bool anual)
        {
            return _dbSet.Where(x => x.Anual == true).ToList();
        }

        public Plano GetPlanByPessoaEmail(Pessoa pessoa)
        {
            if (pessoa == null)
                throw new ArgumentNullException("Objeto pessoa nulo.");

            var pessoaObj = _pessoaRepository.GetByEmail(pessoa.Email);

            if(pessoaObj == null)
                throw new ArgumentNullException("Não há nenhum plano cadastrado com este e-mail.");

            return _dbSet
                .Include(x => x.Addons)
                .Include(x => x.Pessoa)
                .FirstOrDefault(x => x.Pessoa.Email == pessoaObj.Email) ?? throw new Exception("Plano não encontrado");

        }



    }
}
