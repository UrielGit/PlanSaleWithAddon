using PlanSaleWithAddon.Entities;
using PlanSaleWithAddon.JWT;
using PlanSaleWithAddon.Service;
using PlanSaleWithAddon.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Extensions;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PlanSaleWithAddon.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("nova-conta")]
        public async Task<IActionResult> Registrar(RegisterViewModel model)
        {
            if (!ModelState.IsValid) 
                return BadRequest(new { Status = ResponseCodes.BadRequest.GetDisplayName(), 
                                        StatusCode = ResponseCodes.BadRequest,
                                        Message = "Dados informados não são válidos, objeto incorreto.",
                                        Erros = ModelState.Values.SelectMany(e => e.Errors) });

            if (model.Password != model.ConfirmPassword)
                return BadRequest(new { Status = ResponseCodes.Forbidden.GetDisplayName(),
                                        StatusCode = ResponseCodes.Forbidden,
                                        Message = "As senhas informadas não conferem." });

            var existsName = _userManager.FindByNameAsync(model?.Username?.ToLower()).Result != null ? true : false;
            var existsEmail = _userManager.FindByEmailAsync(model?.Email?.ToLower()).Result != null ? true : false;

            if (existsName || existsEmail)
                return BadRequest(new { Status = ResponseCodes.NotAcceptable.GetDisplayName(), 
                                        StatusCode = ResponseCodes.NotAcceptable, 
                                        Message = "O usuário ou email informado já se encontram cadastrados no sistema." });

            var user = new IdentityUser
            {
                UserName = model.Username,
                Email = model.Email,
                PasswordHash = model.Password
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return UnprocessableEntity(new { Status = ResponseCodes.InternalServerError.GetDisplayName(), 
                                                 StatusCode = ResponseCodes.BadRequest, 
                                                 Erros = result.Errors, 
                                                 Message = "Erro interno, não foi possível processar os dados informados." });

            await _signInManager.SignInAsync(user, false);

            return Ok(new { Status = ResponseCodes.OK.GetDisplayName(), StatusCode = ResponseCodes.OK, Message = "Usuário cadastrado com sucesso!" });

        }

        [HttpPost("entrar")]
        public async Task<IActionResult> Entrar(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new {
                                        Status = ResponseCodes.BadRequest.GetDisplayName(),
                                        StatusCode = ResponseCodes.BadRequest,
                                        Message = "Dados informados não são válidos, objeto incorreto.",
                                        Erros = ModelState.Values.SelectMany(e => e.Errors) });

            // último parâmetro é para bloqueio de usuário temporariamente caso persistência de login
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GerarJwt(authClaims);

                return Ok(new { Status = ResponseCodes.OK.GetDisplayName(),
                                StatusCode = ResponseCodes.OK,
                                Message = "Usuário logado com sucesso!",
                                SecurityToken = new JwtSecurityTokenHandler().WriteToken(token), 
                                Expiration = token.ValidTo });
            }
            else
            {
                return Unauthorized(new { Status = ResponseCodes.Unauthorized.GetDisplayName(), 
                                      StatusCode = ResponseCodes.Unauthorized, 
                                      Message = "Usuário ou senha inválido." });
            }
            

        }        

        private JwtSecurityToken GerarJwt(List<Claim> listAuthClaims)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:Secret"]));

            var tokenDescriptor = new JwtSecurityToken
            (
                issuer: _configuration["JWTSettings:Author"],
                audience: _configuration["JWTSettings:Valid"],
                expires: DateTime.Now.AddHours(6),
                claims: listAuthClaims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return tokenDescriptor;

        }

    }
}
