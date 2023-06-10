using ExtremeVacation.Api.Data;
using ExtremeVacation.Api.Entities;
using ExtremeVacation.Api.Repositories.Contracts;
using ExtremeVacation.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ExtremeVacation.Api.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ExtremeVacationDbContext extremeVacationDbContext;

        public CartRepository(ExtremeVacationDbContext extremeVacationDbContext)
        {
            this.extremeVacationDbContext = extremeVacationDbContext;
        }

        private async Task<bool> CartItemAlreadyExists(int cartId, int tripId)
        {
            return await this.extremeVacationDbContext.CartItems.AnyAsync(c => c.CartId == cartId 
                && c.TripId == tripId);
        }

        public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            if (await CartItemAlreadyExists(cartItemToAddDto.CartId, cartItemToAddDto.TripId) == false)
            {
                var item = await (from trip in this.extremeVacationDbContext.Trips
                                  where trip.Id == cartItemToAddDto.TripId
                                  select new CartItem
                                  {
                                      CartId = cartItemToAddDto.CartId,
                                      TripId = trip.Id,
                                      Duration = trip.Duration
                                  }).SingleOrDefaultAsync();

                if (item != null)
                {
                    var result = await this.extremeVacationDbContext.CartItems.AddAsync(item);
                    await this.extremeVacationDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }
            
            return null;
        }

        public async Task<CartItem> DeleteItem(int id)
        {
            var item = await this.extremeVacationDbContext.CartItems.FindAsync(id);

            if (item != null)
            {
                this.extremeVacationDbContext.CartItems.Remove(item);
                await this.extremeVacationDbContext.SaveChangesAsync();
            }

            return item;
        }

        public async Task<CartItem> GetItem(int id)
        {
            return await(from cart in this.extremeVacationDbContext.Carts
                         join cartItem in this.extremeVacationDbContext.CartItems
                         on cart.Id equals cartItem.CartId
                         where cartItem.Id == id
                         select new CartItem
                         {
                             Id = cartItem.Id,
                             TripId = cartItem.TripId,
                             Duration = cartItem.Duration,
                             CartId = cartItem.CartId,
                         }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetItems(int userId)
        {
            return await (from cart in this.extremeVacationDbContext.Carts
                          join cartItem in this.extremeVacationDbContext.CartItems
                          on cart.Id equals cartItem.CartId
                          where cart.UserId == userId
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              TripId = cartItem.TripId,
                              Duration = cartItem.Duration,
                              CartId = cartItem.CartId,
                          }).ToListAsync();
        }                
    }
}
