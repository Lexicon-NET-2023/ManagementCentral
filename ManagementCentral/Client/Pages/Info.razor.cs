using System.Security.Claims;
using ManagementCentral.Client.Services;
using ManagementCentral.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace ManagementCentral.Client.Pages
{
    public partial class Info
    {
        IEnumerable<Claim> Claims { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            Claims = authState.User.Claims;
            
            if (authState.User.IsInRole("Admin"))
            {
                // gör någonting som Admin
            }

            await base.OnInitializedAsync();
        }

    }
}
