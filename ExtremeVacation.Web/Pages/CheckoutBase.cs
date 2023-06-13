using ExtremeVacation.Models.Dtos;
using ExtremeVacation.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace ExtremeVacation.Web.Pages
{
    public class CheckoutBase : ComponentBase
    {
        protected IEnumerable<CartItemDto> CartItems { get; set; }
        protected decimal PaymentAmount { get; set; }

        [Inject]
        public ICartService CartService { get; set; }

        [Inject]
        public IManageCartItemsLocalStorageService ManageCartItemsLocalStorageService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                CartItems = await ManageCartItemsLocalStorageService.GetCollection();

                if (CartItems != null)
                {
                    PaymentAmount = CartItems.Sum(p => p.Price);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
