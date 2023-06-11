using ExtremeVacation.Models.Dtos;
using ExtremeVacation.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace ExtremeVacation.Web.Pages
{
    public class TripsByCategoryBase : ComponentBase
    {
        [Parameter]
        public int CategoryId { get; set; }
        [Inject]
        public ITripService TripService { get; set; }
        public IEnumerable<TripDto> Trips { get; set; }
        public string CategoryName { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                Trips = await TripService.GetItemsByCategory(CategoryId);

                if (Trips != null && Trips.Count() > 0)
                {
                    var tripDto = Trips.FirstOrDefault(t => t.CategoryId == CategoryId);
                    if (tripDto != null)
                    {
                        CategoryName = tripDto.CategoryName;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}