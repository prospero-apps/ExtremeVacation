using ExtremeVacation.Models.Dtos;
using ExtremeVacation.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace ExtremeVacation.Web.Pages
{
    public class TripsBase : ComponentBase
    {
        [Inject]
        public ITripService TripService { get; set; }

        [Inject]
        public ICartService CartService { get; set; }

        [Inject]
        public IManageTripsLocalStorageService ManageTripsLocalStorageService { get; set; }

        [Inject]
        public IManageCartItemsLocalStorageService ManageCartItemsLocalStorageService { get; set; }

        public IEnumerable<TripDto> Trips { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await ClearLocalStorage();

                Trips = await ManageTripsLocalStorageService.GetCollection();

                var cartItems = await ManageCartItemsLocalStorageService.GetCollection();
                var totalTrips = cartItems.Count();

                CartService.RaiseEventOnCartChanged(totalTrips);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            
        }

        protected IOrderedEnumerable<IGrouping<int, TripDto>> GetGroupedTripsByCategory() 
        { 
            return from trip in Trips
                   group trip by trip.CategoryId into tripsByCategoryGroup
                   orderby tripsByCategoryGroup.Key
                   select tripsByCategoryGroup;
        }

        protected string GetCategoryName(IGrouping<int, TripDto> groupedTripDtos) 
        {
            return groupedTripDtos.FirstOrDefault(tg => tg.CategoryId == groupedTripDtos.Key).CategoryName;
        }

        private async Task ClearLocalStorage()
        {
            await ManageTripsLocalStorageService.RemoveCollection();
            await ManageCartItemsLocalStorageService.RemoveCollection();
        }
    }
}
