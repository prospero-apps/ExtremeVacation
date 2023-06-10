using ExtremeVacation.Models.Dtos;

namespace ExtremeVacation.Web.Services.Contracts
{
    public interface ICartService
    {
        Task<List<CartItemDto>> GetItems(int userId);
        Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto);
        Task<CartItemDto> DeleteItem(int id);

        event Action<int> OnCartChanged;
        void RaiseEventOnCartChanged(int totalTrips);
    }
}
