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

        [Inject]
        public IManageTripsLocalStorageService ManageTripsLocalStorageService { get; set; }
               
        public IEnumerable<TripDto> Trips { get; set; }
        public string CategoryName { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                Trips = await GetTripCollectionByCategoryId(CategoryId);

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

        private async Task<IEnumerable<TripDto>> GetTripCollectionByCategoryId(int categoryId)
        {
            var tripCollection = await ManageTripsLocalStorageService.GetCollection();

            if (tripCollection != null)
            {
                return tripCollection.Where(t => t.CategoryId == categoryId);
            }
            else
            {
                return await TripService.GetItemsByCategory(categoryId);
            }
        }
    }
}