using System.Collections.Generic;
using System.Threading.Tasks;
using Dpx.Iot.Common.Entities;
using Dpx.IotPlatformAdministration.Data;
using Microsoft.AspNetCore.Components;

namespace Dpx.IotPlatformAdministration.Pages
{
    public class PointsPageBase : ComponentBase
    {
        public List<Point> Points { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private PointService PointService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Points = await PointService.GetAsync();
        }

        protected void OnSelect() => NavigationManager.NavigateTo($"home");
    }
}
