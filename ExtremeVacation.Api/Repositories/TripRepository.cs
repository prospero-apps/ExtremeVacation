using ExtremeVacation.Api.Data;
using ExtremeVacation.Api.Entities;
using ExtremeVacation.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ExtremeVacation.Api.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly ExtremeVacationDbContext extremeVacationDbContext;

        public TripRepository(ExtremeVacationDbContext extremeVacationDbContext)
        {
            this.extremeVacationDbContext = extremeVacationDbContext;
        }

        public async Task<IEnumerable<TripCategory>> GetCategories()
        {
            var categories = await this.extremeVacationDbContext.TripCategories.ToListAsync();
            return categories;
        }

        public Task<TripCategory> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Trip> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Trip>> GetItems()
        {
            var trips = await this.extremeVacationDbContext.Trips.ToListAsync();
            return trips;
        }
    }
}
