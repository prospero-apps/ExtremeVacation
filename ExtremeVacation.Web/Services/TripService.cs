using ExtremeVacation.Models.Dtos;
using ExtremeVacation.Web.Services.Contracts;
using System.Net.Http.Json;

namespace ExtremeVacation.Web.Services
{
    public class TripService : ITripService
    {
        private readonly HttpClient httpClient;

        public TripService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<TripDto>> GetItems()
        {
            try
            {
                var trips = await this.httpClient.GetFromJsonAsync<IEnumerable<TripDto>>("api/Trip");
                return trips;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
