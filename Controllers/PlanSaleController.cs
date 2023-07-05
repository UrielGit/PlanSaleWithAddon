using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using PlanSaleWithAddon.Entities;
using PlanSaleWithAddon.Entities.ValueObjects;
using PlanSaleWithAddon.Repositories._Interfaces;
using PlanSaleWithAddon.ViewModels;

namespace PlanSaleWithAddon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanSaleController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPlanoRepository _planoRepository;

        public PlanSaleController(IPessoaRepository pessoaRepository, IPlanoRepository planoRepository)
        {
            _pessoaRepository = pessoaRepository;
            _planoRepository = planoRepository;
        }

        [HttpPost("insert-plan")]
        public IActionResult ComprarPlano(PlanoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    Status = ResponseCodes.BadRequest.GetDisplayName(),
                    StatusCode = ResponseCodes.BadRequest,
                    Message = "Dados informados não são válidos, objeto incorreto.",
                    Erros = ModelState.Values.SelectMany(e => e.Errors)
                });

            
            var plano = new Plano(EnumPlanoValidation(model.TipoPlano), model.Anual, model.ValorTotal);

            model.Addons = model.AddonsComprados != null ? EnumAddonValidation(model.AddonsComprados) : new List<AddonViewModel>();

            if (model.Addons != null && model.Addons.Any())
                plano.Addons = model.Addons.Select(vm => new Addon(vm.TipoAddon, vm.Valor)).ToList();
            else
                plano.Addons = new List<Addon>();

            var pessoa = new Pessoa(
                model.Nome,
                model.Telefone,
                model.Email);

            var returnResult = _planoRepository.AddWithPessoa(plano, pessoa);

            return Ok(new
            {
                Status = ResponseCodes.OK.GetDisplayName(),
                StatusCode = ResponseCodes.OK,
                Message = "Plano cadastrado com sucesso.",
            });

        }

        private TipoPlano EnumPlanoValidation(string tipoPlano)
        {
            string[] aTipoPlano = { "Arcade", "Advanced", "Pro" };
            TipoPlano eTipoPlano = TipoPlano.Arcade;

            if (tipoPlano == aTipoPlano[0])
                eTipoPlano = TipoPlano.Arcade;
            else if (tipoPlano == aTipoPlano[1])
                eTipoPlano = TipoPlano.Advanced;
            else if (tipoPlano == aTipoPlano[2])
                eTipoPlano = TipoPlano.Pro;

            return eTipoPlano;
        }

        private List<AddonViewModel> EnumAddonValidation(string[] tipoAddon)
        {
            string[] aTipoPlano = { "Online service", "Larger storage", "Customizable Profile" };
            var listAddonVm = new List<AddonViewModel>();

            foreach (string tipoAddonItem in tipoAddon) 
            {

                if (tipoAddonItem == aTipoPlano[0])
                {
                    listAddonVm.Add(new AddonViewModel { TipoAddon = TipoAddon.OnlineService, Valor = 4.86M * 1 });
                }
                else if (tipoAddonItem == aTipoPlano[1])
                {
                    listAddonVm.Add(new AddonViewModel { TipoAddon = TipoAddon.LargerStorage, Valor = 4.86M * 2 });
                }
                else if (tipoAddonItem == aTipoPlano[2])
                {
                    listAddonVm.Add(new AddonViewModel { TipoAddon = TipoAddon.CustomizableProfile, Valor = 4.86M * 3 });
                }
            }

            return listAddonVm;
        }

    }
}
