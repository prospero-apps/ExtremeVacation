using ExtremeVacation.Models.Dtos;

namespace ExtremeVacation.Web.Services.Contracts
{
    public interface IManageTripsLocalStorageService
    {
        Task<IEnumerable<TripDto>> GetCollection();
        Task RemoveCollection();
    }
}
