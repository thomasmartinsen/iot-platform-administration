using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iot_platform_administration.Data;
using Microsoft.AspNetCore.Components;

namespace iot_platform_administration.Pages
{
    public class PointsPageBase : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private PointService PointService { get; set; }

        public List<Data.Models.Ui.Point> Points { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Points = await PointService.GetAsync();
        }

        protected void OnSelect() => NavigationManager.NavigateTo($"home");
    }
}
