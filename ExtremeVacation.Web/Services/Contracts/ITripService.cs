using ExtremeVacation.Models.Dtos;

namespace ExtremeVacation.Web.Services.Contracts
{
    public interface ITripService
    {
        Task<IEnumerable<TripDto>> GetItems();
    }
}
