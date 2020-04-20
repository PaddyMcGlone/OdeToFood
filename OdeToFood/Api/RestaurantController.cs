using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        #region fields
        private readonly OdeToFoodDbContext _context;

        #endregion

        #region constructor
        public RestaurantController(OdeToFoodDbContext context)
        {
            _context = context;
        }
        #endregion

        #region actions

        [HttpGet]
        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _context.Restaurants;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurant([FromBody]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
                return BadRequest("Null restaurant");

            return Ok(restaurant);
        }

        #endregion

    }
}