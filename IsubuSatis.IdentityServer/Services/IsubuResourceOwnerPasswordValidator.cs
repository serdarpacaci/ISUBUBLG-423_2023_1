using IdentityModel;
using IdentityServer4.Validation;
using IsubuSatis.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace IsubuSatis.IdentityServer.Services
{
    public class IsubuResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IsubuResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _userManager.FindByEmailAsync(context.UserName);

            if (user is null)
            {
                AddError(context);

                return;
            }

            var passWordDogruMu = await _userManager.CheckPasswordAsync(user, context.Password);

            if (!passWordDogruMu)
            {
                AddError(context);

                return;
            }

            context.Result = new GrantValidationResult(user.Id.ToString(),
                OidcConstants.AuthenticationMethods.Password);

        }

        private void AddError(ResourceOwnerPasswordValidationContext context)
        {
            context.Result.CustomResponse = new System.Collections.Generic.Dictionary<string, object>
                {
                    { "errors", "E-Posta ya da şifre hatalı" }
                };
        }
    }
}
