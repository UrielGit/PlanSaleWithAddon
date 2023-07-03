using PlanSaleWithAddon.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace PlanSaleWithAddon.Service
{
    public class APIValidation
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public APIValidation(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public bool ValidaExistenciaCadastro(RegisterViewModel model)
        {

            var existsUser = _userManager.FindByNameAsync(model?.Username?.ToLower()) != null ||
                                 _userManager.FindByEmailAsync(model?.Email?.ToLower()) != null ? true : false;

            if (existsUser)
                return true;
            else
                return false;
        }


    }
}
