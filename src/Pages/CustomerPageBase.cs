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

            if (Customer.CustomerTier == null)
            {
                Customer.CustomerTier = new CustomerTier
                {
                    CustomerTierLevel = 0,
                    Users = 10,
                    Points = 10,
                };
            }
        }

        protected async Task UpdateAsync()
        {
            await CustomerService.UpdateAsync(Customer);
            NavigationManager.NavigateTo($"customers");
        }

        protected async Task OnUpdate() => await UpdateAsync();

        protected void OnCancel() => NavigationManager.NavigateTo($"customers");
    }
}
