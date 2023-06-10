using ExtremeVacation.Models.Dtos;
using ExtremeVacation.Web.Services.Contracts;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace ExtremeVacation.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient httpClient;
        public event Action<int> OnCartChanged;

        public CartService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }               

        public async Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<CartItemToAddDto>("api/Cart", cartItemToAddDto);
            
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CartItemDto);
                    }

                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
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

        public async Task<CartItemDto> DeleteItem(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/Cart/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
                }

                return default(CartItemDto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CartItemDto>> GetItems(int userId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Cart/{userId}/GetItems");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CartItemDto>().ToList();
                    }

                    return await response.Content.ReadFromJsonAsync<List<CartItemDto>>();
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

        public void RaiseEventOnCartChanged(int totalTrips)
        {
            if (OnCartChanged != null)
            {
                OnCartChanged.Invoke(totalTrips);
            }
        }
    }
}
