using Blazored.LocalStorage;
using ExtremeVacation.Models.Dtos;
using ExtremeVacation.Web.Services.Contracts;

namespace ExtremeVacation.Web.Services
{
    public class ManageCartItemsLocalStorageService : IManageCartItemsLocalStorageService
    {
        private readonly ILocalStorageService localStorageService;
        private readonly ICartService cartService;

        const string key = "CartItemCollection";

        public ManageCartItemsLocalStorageService(ILocalStorageService localStorageService, ICartService cartService)
        {
            this.localStorageService = localStorageService;
            this.cartService = cartService;
        }

        public async Task<List<CartItemDto>> GetCollection()
        {
            return await this.localStorageService.GetItemAsync<List<CartItemDto>>(key)
                ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await this.localStorageService.RemoveItemAsync(key);
        }

        public async Task SaveCollection(List<CartItemDto> cartItemDtos)
        {
            await this.localStorageService.SetItemAsync(key, cartItemDtos);
        }

        private async Task<List<CartItemDto>> AddCollection()
        {
            var cartCollection = await this.cartService.GetItems(HardCodedData.UserId);

            if (cartCollection != null)
            {
                await this.localStorageService.SetItemAsync(key, cartCollection);
            }

            return cartCollection;
        }
    }
}
