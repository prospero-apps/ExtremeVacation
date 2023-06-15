using Blazored.LocalStorage;
using ExtremeVacation.Web;
using ExtremeVacation.Web.Services;
using ExtremeVacation.Web.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace ExtremeVacation.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7077/") });
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://extremevacationapi20230612222347.azurewebsites.net/") });


            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


            builder.Services.AddScoped<ITripService, TripService>();
            builder.Services.AddScoped<ICartService, CartService>();

            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddScoped<IManageTripsLocalStorageService, ManageTripsLocalStorageService>();
            builder.Services.AddScoped<IManageCartItemsLocalStorageService, ManageCartItemsLocalStorageService>();

            await builder.Build().RunAsync();
        }
    }
}