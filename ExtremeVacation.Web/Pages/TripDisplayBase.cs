using ExtremeVacation.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace ExtremeVacation.Web.Pages
{
    public class TripDisplayBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<TripDto> Trips { get; set; }
    }
}
