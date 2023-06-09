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

        public async Task<TripDto> GetItem(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Trip/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(TripDto);
                    }

                    return await response.Content.ReadFromJsonAsync<TripDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TripDto>> GetItems()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/Trip");
                
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<TripDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<TripDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
