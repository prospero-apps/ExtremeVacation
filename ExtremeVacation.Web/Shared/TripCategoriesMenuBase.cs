using ExtremeVacation.Models.Dtos;
using ExtremeVacation.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace ExtremeVacation.Web.Shared
{
    public class TripCategoriesMenuBase : ComponentBase
    {
        [Inject]
        public ITripService TripService { get; set; }

        public IEnumerable<TripCategoryDto> TripCategoryDtos { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                TripCategoryDtos = await TripService.GetTripCategories();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
