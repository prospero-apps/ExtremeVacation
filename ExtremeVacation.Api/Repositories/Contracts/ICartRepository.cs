using ExtremeVacation.Api.Entities;
using ExtremeVacation.Models.Dtos;

namespace ExtremeVacation.Api.Repositories.Contracts
{
    public interface ICartRepository
    {
        Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto);
        Task<CartItem> DeleteItem(int id);
        Task<CartItem> GetItem(int id);
        Task<IEnumerable<CartItem>> GetItems(int userId);
    }
}
