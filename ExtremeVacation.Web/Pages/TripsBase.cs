﻿using ExtremeVacation.Models.Dtos;
using ExtremeVacation.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace ExtremeVacation.Web.Pages
{
    public class TripsBase : ComponentBase
    {
        [Inject]
        public ITripService TripService { get; set; }
        public IEnumerable<TripDto> Trips { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Trips = await TripService.GetItems();
        }

        protected IOrderedEnumerable<IGrouping<int, TripDto>> GetGroupedTripsByCategory() 
        { 
            return from trip in Trips
                   group trip by trip.CategoryId into tripsByCategoryGroup
                   orderby tripsByCategoryGroup.Key
                   select tripsByCategoryGroup;
        }

        protected string GetCategoryName(IGrouping<int, TripDto> groupedTripDtos) 
        {
            return groupedTripDtos.FirstOrDefault(tg => tg.CategoryId == groupedTripDtos.Key).CategoryName;
        }
    }
}
