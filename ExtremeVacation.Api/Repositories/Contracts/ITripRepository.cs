using ExtremeVacation.Api.Entities;

namespace ExtremeVacation.Api.Repositories.Contracts
{
    public interface ITripRepository
    {
        Task<IEnumerable<Trip>> GetItems();
        Task<IEnumerable<TripCategory>> GetCategories();
        Task<Trip> GetItem(int id);
        Task<TripCategory> GetCategory(int id);
        Task<IEnumerable<Trip>> GetItemsByCategory(int id);
    }
}
