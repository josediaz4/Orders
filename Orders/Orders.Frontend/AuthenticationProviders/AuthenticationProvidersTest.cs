using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Orders.Frontend.AuthenticationProviders
{
    public class AuthenticationProvidersTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimous = new ClaimsIdentity();
            var user = new ClaimsIdentity(authenticationType: "test");
            var admin = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName","Manu"),
                new Claim("LastName","Díaz"),
                new Claim(ClaimTypes.Name,"manu@yopmail.com"),
                new Claim(ClaimTypes.Role, "Admin")
            },
            authenticationType: "test");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(user)));
        }
    }
}