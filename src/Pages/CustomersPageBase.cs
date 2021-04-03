using System.Collections.Generic;
using System.Threading.Tasks;
using Dpx.Iot.Common.Entities;
using Dpx.IotPlatformAdministration.Data;
using Microsoft.AspNetCore.Components;

namespace Dpx.IotPlatformAdministration.Pages
{
    public class CustomersPageBase : ComponentBase
    {
        public IEnumerable<Customer> Customers { get; set; }

        [Parameter]
        public string Action { get; set; }

        [Inject]
        private CustomerService CustomerService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Customers = await CustomerService.GetAsync();
        }

        protected void OnSelect(string clientid) => NavigationManager.NavigateTo($"customer/{clientid}");
    }
}
