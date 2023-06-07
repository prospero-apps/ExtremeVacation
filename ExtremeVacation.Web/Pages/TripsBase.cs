using ExtremeVacation.Models.Dtos;
using ExtremeVacation.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace ExtremeVacation.Web.Pages
{
    public class TripsBase : ComponentBase
    {
        [Inject]
        public ITripService TripService { get; set; }
        public IEnumerable<TripDto> Trips { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Trips = await TripService.GetItems();
        }
    }
}
