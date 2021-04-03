using System.Threading.Tasks;
using Dpx.Iot.Common.Entities;
using Dpx.IotPlatformAdministration.Data;
using Microsoft.AspNetCore.Components;

namespace Dpx.IotPlatformAdministration.Pages
{
    public class CustomerPageBase : ComponentBase
    {
        public Customer Customer { get; set; }

        [Parameter]
        public string ClientId { get; set; }

        [Inject]
        private CustomerService CustomerService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Customer = await CustomerService.GetFromClientIdAsync(ClientId);
        }

        protected void OnCancel() => NavigationManager.NavigateTo($"customers");
    }
}
