using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using NUShop.Data.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NUShop.WebAPI.Helpers
{
    public class CustomClaimsPrincipal : UserClaimsPrincipalFactory<AppUser, AppRole>
    {
        public CustomClaimsPrincipal(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }

        public override async Task<ClaimsPrincipal> CreateAsync(AppUser user)
        {
            var claimsPrincipal = await base.CreateAsync(user);
            var roles = await UserManager.GetRolesAsync(user);

            var claims = new[]
            {
                new Claim("UserId", user.Id.ToString()),
                new Claim("Email", user.Email ?? string.Empty),
                new Claim("FullName", user.FullName ?? string.Empty),
                new Claim("Avatar", user.Avatar ?? string.Empty),
                new Claim("Roles", string.Join(";", roles)),
            };

            ((ClaimsIdentity)claimsPrincipal.Identity).AddClaims(claims);

            return claimsPrincipal;
        }
    }
}