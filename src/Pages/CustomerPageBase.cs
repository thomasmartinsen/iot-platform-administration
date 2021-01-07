using System.Threading.Tasks;
using iot_platform_administration.Data;
using Microsoft.AspNetCore.Components;

namespace iot_platform_administration.Pages
{
    public class CustomerPageBase : ComponentBase
    {
        [Inject]
        private CustomerService customerService { get; set; }

        public Data.Models.Ui.Customer Customer { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            Customer = await customerService.GetAsync();
        }
    }
}
