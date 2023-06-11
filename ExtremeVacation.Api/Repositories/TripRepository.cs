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

        public async Task<TripCategory> GetCategory(int id)
        {
            var category = await extremeVacationDbContext.TripCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Trip> GetItem(int id)
        {
            var trip = await extremeVacationDbContext.Trips
                                .Include(t => t.TripCategory)
                                .SingleOrDefaultAsync(t => t.Id == id);
            return trip;
        }

        public async Task<IEnumerable<Trip>> GetItems()
        {
            var trips = await this.extremeVacationDbContext.Trips
                                .Include(t => t.TripCategory).ToListAsync();

            return trips;
        }

        public async Task<IEnumerable<Trip>> GetItemsByCategory(int id)
        {
            var trips = await this.extremeVacationDbContext.Trips
                                .Include(t => t.TripCategory)
                                .Where(t => t.CategoryId == id).ToListAsync();

            return trips;
        }
    }
}
