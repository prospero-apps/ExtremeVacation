using ExtremeVacation.Api.Entities;
using ExtremeVacation.Models.Dtos;

namespace ExtremeVacation.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<TripDto> ConvertToDto(this IEnumerable<Trip> trips,
            IEnumerable<TripCategory> tripCategories)
        {
            return  (from Trip trip in trips
                     join tripCategory in tripCategories
                     on trip.CategoryId equals tripCategory.Id
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
                         CategoryId = trip.CategoryId,
                         CategoryName = tripCategory.Name
                     }).ToList();
        }
    }
}
