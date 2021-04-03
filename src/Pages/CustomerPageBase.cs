using System.Threading.Tasks;
using Dpx.Iot.Common.Entities;
using Dpx.IotPlatformAdministration.Data;
using Microsoft.AspNetCore.Components;

namespace Dpx.IotPlatformAdministration.Pages
{
    public class CustomerPageBase : ComponentBase
    {
        public Customer Customer { get; set; }

        [Inject]
        private CustomerService CustomerService { get; set; }
        
        ////protected override async Task OnInitializedAsync()
        ////{
        ////    Customer = await CustomerService.GetAsync();
        ////}
    }
}
