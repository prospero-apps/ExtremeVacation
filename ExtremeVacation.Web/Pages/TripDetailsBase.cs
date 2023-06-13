using ExtremeVacation.Models.Dtos;
using ExtremeVacation.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace ExtremeVacation.Web.Pages
{
    public class TripDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public ITripService TripService { get; set; }

        [Inject]
        public ICartService CartService { get; set; }

        [Inject]
        public IManageTripsLocalStorageService ManageTripsLocalStorageService { get; set; }

        [Inject]
        public IManageCartItemsLocalStorageService ManageCartItemsLocalStorageService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public TripDto Trip { get; set; }

        public string ErrorMessage { get; set; }

        private List<CartItemDto> CartItems { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                CartItems = await ManageCartItemsLocalStorageService.GetCollection();
                Trip = await GetTripById(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task AddToCart_Click(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var cartItemDto = await CartService.AddItem(cartItemToAddDto);

                if (cartItemDto != null)
                {
                    CartItems.Add(cartItemDto);
                    await ManageCartItemsLocalStorageService.SaveCollection(CartItems);
                }

                NavigationManager.NavigateTo("/Cart");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<TripDto> GetTripById(int id)
        {
            var tripDtos = await ManageTripsLocalStorageService.GetCollection();

            if (tripDtos != null)
            {
                return tripDtos.SingleOrDefault(t => t.Id == id);
            }

            return null;
        }
    }
}
