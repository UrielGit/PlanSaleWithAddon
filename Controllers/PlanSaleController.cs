using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using PlanSaleWithAddon.Entities;
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
            if(!ModelState.IsValid)
                return BadRequest(new
                {
                    Status = ResponseCodes.BadRequest.GetDisplayName(),
                    StatusCode = ResponseCodes.BadRequest,
                    Message = "Dados informados não são válidos, objeto incorreto.",
                    Erros = ModelState.Values.SelectMany(e => e.Errors)
                });

            var plano = new Plano(model.TipoPlano, model.Anual, model.ValorTotal);

            if (model.Addons != null && model.Addons.Any())
                plano.Addons = model.Addons.Select(vm => new Addon(vm.TipoAddon, vm.Valor)).ToList();
            else
                plano.Addons = new List<Addon>();

            var pessoa = new Pessoa(
                model.Pessoa.Nome,
                model.Pessoa.Telefone,
                model.Pessoa.Email);

            _planoRepository.AddWithPessoa(plano, pessoa);
           
            return Ok(new { Status = ResponseCodes.OK.GetDisplayName(),
                            StatusCode = ResponseCodes.OK,
                            Message = "Plano cadastrado com sucesso.",});

        }

    }
}
