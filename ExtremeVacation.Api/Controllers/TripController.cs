using ExtremeVacation.Api.Extensions;
using ExtremeVacation.Api.Repositories.Contracts;
using ExtremeVacation.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeVacation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripRepository tripRepository;

        public TripController(ITripRepository tripRepository)
        {
            this.tripRepository = tripRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripDto>>> GetItems()
        {
            try
            {
                var trips = await this.tripRepository.GetItems();
                var tripCategories = await this.tripRepository.GetCategories();

                if (trips == null || tripCategories == null)
                {
                    return NotFound();
                }
                else
                {
                    var tripDtos = trips.ConvertToDto(tripCategories);
                    return Ok(tripDtos);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Server error retrieving data from the database");
            }
        }
    }
}
