using ExtremeVacation.Api.Extensions;
using ExtremeVacation.Api.Repositories.Contracts;
using ExtremeVacation.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtremeVacation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository cartRepository;
        private readonly ITripRepository tripRepository;

        public CartController(ICartRepository cartRepository, ITripRepository tripRepository)
        {
            this.cartRepository = cartRepository;
            this.tripRepository = tripRepository;
        }

        [HttpGet]
        [Route("{userId}/GetItems")]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int userId)
        {
            try
            {
                var cartItems = await this.cartRepository.GetItems(userId);

                if (cartItems == null)
                {
                    return NoContent();
                }

                var trips = await this.tripRepository.GetItems();

                if (trips == null)
                {
                    throw new Exception("No trips exist in the system.");
                }

                var cartItemsDto = cartItems.ConvertToDto(trips);

                return Ok(cartItemsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CartItemDto>> GetItem(int id)
        {
            try
            {
                var cartItem = await this.cartRepository.GetItem(id);

                if (cartItem == null)
                {
                    return NotFound();
                }

                var trip = await this.tripRepository.GetItem(cartItem.TripId);

                if (trip == null)
                {
                    return NotFound();
                }

                var CartItemDto = cartItem.ConvertToDto(trip);
                return Ok(CartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CartItemDto>> PostItem([FromBody] CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var newCartItem = await this.cartRepository.AddItem(cartItemToAddDto);

                if (newCartItem == null)
                {
                    return NoContent();
                }

                var trip = await this.tripRepository.GetItem(newCartItem.TripId);

                if (trip == null)
                {
                    throw new Exception("Something went wrong.");
                }

                var newCartItemDto = newCartItem.ConvertToDto(trip);

                return CreatedAtAction(nameof(GetItem), new { id = newCartItemDto.Id }, newCartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CartItemDto>> DeleteItem(int id)
        {
            try
            {
                var cartItem = await this.cartRepository.DeleteItem(id);

                if (cartItem == null)
                {
                    return NotFound();
                }

                var trip = await this.tripRepository.GetItem(cartItem.TripId);

                if (trip == null)
                {
                    return NotFound();
                }

                var cartItemDto = cartItem.ConvertToDto(trip);

                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }    
}
