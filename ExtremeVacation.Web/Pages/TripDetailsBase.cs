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
        public NavigationManager NavigationManager { get; set; }

        public TripDto Trip { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Trip = await TripService.GetItem(Id);
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
                NavigationManager.NavigateTo("/Cart");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
