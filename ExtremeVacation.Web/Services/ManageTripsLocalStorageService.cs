using Blazored.LocalStorage;
using ExtremeVacation.Models.Dtos;
using ExtremeVacation.Web.Services.Contracts;

namespace ExtremeVacation.Web.Services
{
    public class ManageTripsLocalStorageService : IManageTripsLocalStorageService
    {
        private readonly ILocalStorageService localStorageService;
        private readonly ITripService tripService;

        private const string key = "TripCollection";

        public ManageTripsLocalStorageService(ILocalStorageService localStorageService,
            ITripService tripService)
        {
            this.localStorageService = localStorageService;
            this.tripService = tripService;
        }

        public async Task<IEnumerable<TripDto>> GetCollection()
        {
            return await this.localStorageService.GetItemAsync<IEnumerable<TripDto>>(key)
                ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await this.localStorageService.RemoveItemAsync(key);
        }

        private async Task<IEnumerable<TripDto>> AddCollection()
        {
            var tripCollection = await this.tripService.GetItems();

            if (tripCollection == null)
            {
                await this.localStorageService.SetItemAsync(key, tripCollection);
            }

            return tripCollection;
        }
    }
}
