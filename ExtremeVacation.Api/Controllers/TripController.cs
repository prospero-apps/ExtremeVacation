using ExtremeVacation.Api.Extensions;
using ExtremeVacation.Api.Repositories.Contracts;
using ExtremeVacation.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeVacation.Api.Controllers
{
    [Route("api/trips")]
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

                if (trips == null)
                {
                    return NotFound();
                }
                else
                {
                    var tripDtos = trips.ConvertToDto();
                    return Ok(tripDtos);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Server error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TripDto>> GetItem(int id)
        {
            try
            {
                var trip = await this.tripRepository.GetItem(id);

                if (trip == null)
                {
                    return BadRequest();
                }
                else
                {
                    var tripDto = trip.ConvertToDto();
                    return Ok(tripDto);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Server error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route(nameof(GetTripCategories))]
        public async Task<ActionResult<IEnumerable<TripCategoryDto>>> GetTripCategories()
        {
            try
            {
                var tripCategories = await tripRepository.GetCategories();
                var tripCategoryDtos = tripCategories.ConvertToDto();

                return Ok(tripCategoryDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Server error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("{categoryId}/GetItemsByCategory")]
        public async Task<ActionResult<IEnumerable<TripDto>>> GetItemsByCategory(int categoryId)
        {
            try
            {
                var trips = await tripRepository.GetItemsByCategory(categoryId);
                var tripDtos = trips.ConvertToDto();

                return Ok(tripDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Server error retrieving data from the database");
            }
        }
    }
}
