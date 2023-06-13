using ExtremeVacation.Models.Dtos;
using ExtremeVacation.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace ExtremeVacation.Web.Pages
{
    public class CartBase : ComponentBase
    {
        [Inject]
        public ICartService CartService { get; set; }

        [Inject]
        public IManageCartItemsLocalStorageService ManageCartItemsLocalStorageService { get; set; }

        public List<CartItemDto> CartItems { get; set; }

        public string ErrorMessage { get; set; }

        protected string TotalPrice { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                CartItems = await ManageCartItemsLocalStorageService.GetCollection();
                CartChanged();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task DeleteCartItem_Click(int id)
        {
            var cartItemDto = await CartService.DeleteItem(id);

            RemoveCartItem(id);
            CartChanged();
        }
                     
        private void CalculateTotalPrice()
        {
            TotalPrice = this.CartItems.Sum(p => p.Price).ToString("C0");
        }

        private CartItemDto GetCartItem(int id)
        {
            return CartItems.FirstOrDefault(i => i.Id == id);
        }

        private async Task RemoveCartItem(int id)
        {
            var cartItemDto = GetCartItem(id);

            CartItems.Remove(cartItemDto);

            await ManageCartItemsLocalStorageService.SaveCollection(CartItems);
        }

        private void CartChanged()
        {
            CalculateTotalPrice();
            CartService.RaiseEventOnCartChanged(CartItems.Count());
        }
    }
}
