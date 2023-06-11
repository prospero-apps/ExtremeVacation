using ExtremeVacation.Api.Entities;
using ExtremeVacation.Models.Dtos;

namespace ExtremeVacation.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<TripCategoryDto> ConvertToDto(this IEnumerable<TripCategory> tripCategories)
        {
            return (from tripCategory in tripCategories
                    select new TripCategoryDto
                    {
                        Id = tripCategory.Id,
                        Name = tripCategory.Name,
                        IconCSS = tripCategory.IconCSS,
                    }).ToList();
        }

        public static IEnumerable<TripDto> ConvertToDto(this IEnumerable<Trip> trips)
        {
            return  (from Trip trip in trips
                     select new TripDto
                     {
                         Id = trip.Id,
                         Name = trip.Name,
                         Destination = trip.Destination,
                         Description = trip.Description,
                         Danger = trip.Danger,
                         ChanceOfSurvival = trip.ChanceOfSurvival,
                         ImageURL = trip.ImageURL,
                         Price = trip.Price,
                         Duration = trip.Duration,
                         CategoryId = trip.TripCategory.Id,
                         CategoryName = trip.TripCategory.Name
                     }).ToList();
        }

        public static TripDto ConvertToDto(this Trip trip)
        {
            return new TripDto
            {
                Id = trip.Id,
                Name = trip.Name,
                Destination = trip.Destination,
                Description = trip.Description,
                Danger = trip.Danger,
                ChanceOfSurvival = trip.ChanceOfSurvival,
                ImageURL = trip.ImageURL,
                Price = trip.Price,
                Duration = trip.Duration,
                CategoryId = trip.TripCategory.Id,
                CategoryName = trip.TripCategory.Name
            };
        }

        public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems,
            IEnumerable<Trip> trips)
        {
            return (from cartItem in cartItems
                    join trip in trips
                    on cartItem.TripId equals trip.Id
                    select new CartItemDto
                    {
                        Id = cartItem.Id,
                        TripId = cartItem.TripId,
                        TripName = trip.Name,
                        TripDestination = trip.Destination,
                        TripDescription = trip.Description,
                        TripImageURL = trip.ImageURL,
                        Price = trip.Price,
                        CartId = cartItem.CartId,
                        Duration = cartItem.Duration
                    }).ToList();
        }

        public static CartItemDto ConvertToDto(this CartItem cartItem, Trip trip)
        {
            return new CartItemDto
            {
                Id = cartItem.Id,
                TripId = cartItem.TripId,
                TripName = trip.Name,
                TripDestination = trip.Destination,
                TripDescription = trip.Description,
                TripImageURL = trip.ImageURL,
                Price = trip.Price,
                CartId = cartItem.CartId,
                Duration = cartItem.Duration
            };
        }
    }
}
